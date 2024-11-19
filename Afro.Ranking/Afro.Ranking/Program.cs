using Afro.Ranking.Application.Influencer;
using Afro.Ranking.DI;
using Afro.Ranking.Persistance;
using Afro.Ranking.Domain.Model.Entities;
using Afro.Ranking.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using Afro.Ranking.Domain.Model.Entities.Admin;
using Afro.Ranking.Application.Admin;
using Afro.Ranking.Persistance.Entities;
using Microsoft.AspNetCore.Identity;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<ApplicationContext>();
        
        builder.Services.AddScopedServices();
        builder.Services.AddIdentity<Afro.Ranking.Persistance.Entities.Admin, IdentityRole>(
              option =>
              {
                option.User.RequireUniqueEmail = true;


              })
               .AddEntityFrameworkStores<ApplicationContext>()
               .AddDefaultTokenProviders();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        var summaries = new[]
        {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();
        var influencerdata = app.MapGroup("/Influencer");
        influencerdata.MapGet("/", GetIndex);
        static async Task<IResult>GetIndex()
        {
            InfluencerService service = new InfluencerService();
            var data = await service.GetInfluencerViewModels();
            return TypedResults.Ok(data.ToArray());
      
           

        }
        var admin = app.MapGroup("/Admin");
        admin.MapPost("/", CreateAdmin);
        admin.MapPost("/Login",Login);
        static async Task<IResult> CreateAdmin( Afro.Ranking.Application.Admin.CreateAdminUserViewModel adminViewModel, UserManager<Afro.Ranking.Persistance.Entities.Admin> userManager)
        {
            CreateAdminUserViewModelValidator validationRules = new CreateAdminUserViewModelValidator();
              validationRules.Validate(adminViewModel);

              Afro.Ranking.Domain.Model.Entities.Admin.Admin adminModel = Afro.Ranking.Domain.Model.Entities.Admin.Admin.Create(adminViewModel.FirstName, adminViewModel.LastName, adminViewModel.Email, adminViewModel.Password);
            Afro.Ranking.Persistance.Entities.Admin entity = new Afro.Ranking.Persistance.Entities.Admin()
            {
                FirstName = adminModel.FirstName.Value,
                LastName = adminModel.LastName.Value,
                Email = adminModel.Email.Value,
                UserName = adminModel.Email.Value,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await userManager.CreateAsync(entity, adminModel.Password.Value);
            return TypedResults.Created($"", result);
        }
        static async Task<IResult> Login(Afro.Ranking.Application.Admin.Login login, UserManager<Afro.Ranking.Persistance.Entities.Admin> userManager, SignInManager<Afro.Ranking.Persistance.Entities.Admin> signInManager)
        {
            LoginValidator validationRules = new LoginValidator();
           var valid = await validationRules.ValidateAsync(login);
           if(valid.IsValid) 
           {
                var user = await userManager.FindByEmailAsync(login.UserId);
                if(user == null) {
                return TypedResults.NotFound();
                }
                var signIn = await signInManager.PasswordSignInAsync(user, login.Password,false, false);
                if(signIn != null && signIn.Succeeded) 
                {
                    return TypedResults.Ok();
                }
                
            }
            return TypedResults.NotFound();
        }


        //admin.MapPost("", async (Afro.Ranking.Domain.Model.Entities.Admin admin, AdminRepository repo) => 
        //  { 
        //      repo.Add(admin);
        //     await  repo.Save();
        //      return Results.Created($"", admin);
        //  });

        app.Run();
    }
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

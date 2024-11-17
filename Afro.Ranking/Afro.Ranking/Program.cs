using Afro.Ranking.Application.Influencer;
using Afro.Ranking.DI;
using Afro.Ranking.Persistance;
using Afro.Ranking.Domain.Model.Entities;
using Afro.Ranking.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        static async Task<IResult> CreateAdmin( Afro.Ranking.Application.Admin.AdminViewModel adminViewModel, AdminRepository repo)
        {
               Admin admin = Admin.Create(adminViewModel.FirstName, adminViewModel.LastName);
            repo.Add(admin);
            await repo.Save();
            return TypedResults.Created($"", admin);
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

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
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Afro.Ranking.ApplicationHostingExtensions;
using Afro.Ranking.Model.RequestDto;
using Afro.Ranking.Model.RequestDto.Validators;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.ConfigureBuilderServices().ConfigureApplicationPipelines();

        //********************************************************EndPoints*****************************************************
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
        //influencerdata.MapGet("/", GetIndex).RequireAuthorization(); //todo revert to authrization after test
        influencerdata.MapGet("/", GetIndex);
        //influencerdata.MapGet("/AddBioData", AddBioData);
        influencerdata.MapPost("/AddBioData", AddBioData);

        static async Task<IResult> AddBioData( ApplicationContext context)
        {
            InfluencerService service = new InfluencerService();
            var data = await service.GetInfluencerViewModels();
            return TypedResults.Ok(data.ToArray());
        }
        static async Task<IResult>GetIndex()
        {
            InfluencerService service = new InfluencerService();
            var data = await service.GetInfluencerViewModels();
            CreateAdminRequestDto dto = new CreateAdminRequestDto();
            //return TypedResults.Ok(data.ToArray());
            return TypedResults.Ok(dto);
        }

        var admin = app.MapGroup("/Admin");
        admin.MapPost("/", CreateAdmin);
        admin.MapPost("/Login",Login);
        
        static async Task<IResult> CreateAdmin(CreateAdminRequestDto adminrequestDto, UserManager<Afro.Ranking.Persistance.Entities.Admin> userManager)
        {
            CreateAdminRequestDtoValidator validator = new();
              validator.Validate(adminrequestDto);

              Afro.Ranking.Domain.Model.Entities.Admin.Admin adminModel = Afro.Ranking.Domain.Model.Entities.Admin.Admin.Create(adminrequestDto.FirstName, adminrequestDto.LastName, adminrequestDto.Email, adminrequestDto.Password);
            Afro.Ranking.Persistance.Entities.Admin entity = new Afro.Ranking.Persistance.Entities.Admin()
            {
                FirstName = adminModel.FirstName.Value,
                LastName = adminModel.LastName.Value,
                Email = adminModel.Email.Value,
                UserName = adminModel.Email.Value,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await userManager.CreateAsync(entity, adminModel.Password.Value);
            if (result.Succeeded) 
            {
                return TypedResults.Created($"", result);
            }
            else
            {
                return TypedResults.Json(new { Message = "Internal Server Error" });
                
            }
            
        }
        static async Task<IResult> Login(Afro.Ranking.Application.Admin.Login login, UserManager<Afro.Ranking.Persistance.Entities.Admin> userManager, SignInManager<Afro.Ranking.Persistance.Entities.Admin> signInManager, IConfiguration config)
        {
            LoginValidator validationRules = new LoginValidator();
           var valid = await validationRules.ValidateAsync(login);
           if(valid.IsValid) 
           {
                var user = await userManager.FindByEmailAsync(login.UserId);
                if(user == null || !(await userManager.CheckPasswordAsync(user , login.Password))) {
                  return TypedResults.Unauthorized();
                }
                // make claims
                var AdminClaims = new List<Claim>
                {
                  new Claim(ClaimTypes.Name, login.UserId),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                              config["JWT:Secret"] ?? throw new InvalidOperationException("JTW with no Secret")));
                var token = new JwtSecurityToken(
                    issuer: config["JWT:ValidIssuer"],
                    audience: config["JWT:ValidAudience"],
                    expires: DateTime.UtcNow.AddHours(1),
                    claims : AdminClaims,
                    signingCredentials :new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

                return TypedResults.Ok(
                           new LoginResponse()
                           {
                           JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                           ExpirationDate = token.ValidTo,
                           }
                        );
               
                
            }
            return TypedResults.Unauthorized();
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

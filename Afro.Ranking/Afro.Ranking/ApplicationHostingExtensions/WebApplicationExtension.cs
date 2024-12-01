using Afro.Ranking.Persistance.Repositories;
using Afro.Ranking.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Afro.Ranking.DI;

namespace Afro.Ranking.ApplicationHostingExtensions
{
    public static class WebApplicationExtension
    {
       public static WebApplication ConfigureBuilderServices( this WebApplicationBuilder builder)
       {
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

            // Config JWT Authentication Config
            var secret = builder.Configuration["JWT:Secret"] ?? throw new InvalidOperationException("JTW with no Secret");
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                         .AddJwtBearer(options =>
                         {
                             options.SaveToken = true;
                             options.TokenValidationParameters = new TokenValidationParameters
                             {
                                 ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                                 ValidAudience = builder.Configuration["JWT:ValidAudience"],
                                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                             };
                         });
            builder.Services.AddAuthorization();
            return builder.Build();
        }
        public static WebApplication ConfigureApplicationPipelines(this WebApplication app)
        {
            app.UseRouting();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}

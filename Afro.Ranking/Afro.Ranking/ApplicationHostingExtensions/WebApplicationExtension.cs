using Afro.Ranking.DI;
using Afro.Ranking.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Afro.Ranking.ApplicationHostingExtensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication ConfigureBuilderServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
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





            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //sw =>
            //{
            //    sw.SwaggerDoc("whatVersion", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "What Title", Version = "what version" });
            //    sw.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            //    {
            //        Name = "Example Authorization",
            //        Type = "basic",
            //        In = ParameterLocation.Header,
            //        Description = ""

            //    });
            //    sw.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //    {
            //          {
            //              new OpenApiSecurityScheme
            //              {
            //                 Reference = new OpenApiReference
            //                   {
            //                         Type = ReferenceType.SecurityScheme,
            //                         Id ="basic"
            //                  }
            //              },
            //              new string[] { }
            //          }
            //    });

            //});



            return builder.Build();
        }
        public static WebApplication ConfigureApplicationPipelines(this WebApplication app)
        {
            app.Use( async (context, next) => 
                            {
                                context.Response.Headers.Append("x-Afro-Ranking", "Best Afrique");
                                await next();
                                  
                                  });
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

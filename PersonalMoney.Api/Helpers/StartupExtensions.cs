using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.Services.AccountType;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.Helpers
{
    internal static class StartupExtensions
    {
        /// <summary>
        /// Adds the local service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="myAllowSpecificOrigins">My allow specific origins.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddLocalServices(this IServiceCollection services, string myAllowSpecificOrigins, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IFireStoreService, FireStoreService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: myAllowSpecificOrigins,
                                  builder =>
                                  {
                                      var corsSection = configuration.GetSection("CORS");
                                      builder
                                      .WithOrigins(corsSection.Get<string[]>())
                                      .WithHeaders("Authorization", "Accept");
                                  });
            });
        }

        /// <summary>
        /// Adds the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Money manager API",
                    Description = "Money manager api is used to handle the CRUD operations of money manger application",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Bhagavan Reddy",
                        Email = "bhagavan44@gmail.com",
                        Url = new Uri("https://twitter.com/bhagavan44"),
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }, new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Uses the swagger services.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseSwaggerServices(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Money manager API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        /// <summary>
        /// Converts the snapshot to model with identifier.
        /// </summary>
        /// <typeparam name="T">The model</typeparam>
        /// <param name="snapshot">The snapshot.</param>
        /// <returns>The model</returns>
        public static T ConvertToWithId<T>(this DocumentSnapshot snapshot) where T : BaseModel
        {
            var result = snapshot.ConvertTo<T>();
            result.Id = snapshot.Id;
            return result;
        }
    }
}
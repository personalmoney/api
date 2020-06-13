using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MoneyManager.Api.Services.AccountType;

namespace MoneyManager.Api.Helpers
{
    internal static class StartupExtensions
    {
        /// <summary>
        /// Adds the local service.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddLocalServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountTypeService, AccountTypeService>();
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
    }
}
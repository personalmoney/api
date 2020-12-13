using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PersonalMoney.Api.Services;
using PersonalMoney.Api.Services.Account;
using PersonalMoney.Api.Services.AccountType;
using PersonalMoney.Api.Services.Category;
using PersonalMoney.Api.Services.Payee;
using PersonalMoney.Api.Services.SubCategory;
using PersonalMoney.Api.Services.Tag;
using PersonalMoney.Api.Services.Transaction;

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
            services.AddTransient<UserResolverService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IPayeeService, PayeeService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: myAllowSpecificOrigins,
                                  builder =>
                                  {
                                      var corsMethods = configuration.GetSection("CORS:Methods");
                                      var corsOrigins = configuration.GetSection("CORS:Origins");
                                      var corsHeaders = configuration.GetSection("CORS:Headers");
                                      builder
                                      .WithMethods(corsMethods.Get<string[]>())
                                      .WithOrigins(corsOrigins.Get<string[]>())
                                      .WithHeaders(corsHeaders.Get<string[]>());
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
                    Title = "Personal money API",
                    Description = "Person money api is used to handle the CRUD operations of personal money application",
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

        public static void AddRateLimiterInitial(this IServiceCollection services, IConfiguration configuration)
        {
            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        }

        public static void AddRateLimiterEnd(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Personal money API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
using AspNetCoreRateLimit;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PersonalMoney.Api.Filters;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api
{
    /// <summary>
    /// The Startup class
    /// </summary>
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>Gets the configuration.</summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services. This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRateLimiterInitial(Configuration);

            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()))
                .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DbContext")));

            services.AddSwaggerServices();
            services.AddAutoMapper(typeof(Startup));
            services.AddLocalServices(MyAllowSpecificOrigins, Configuration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var projectId = Configuration["FireBaseId"];
                    options.Authority = "https://securetoken.google.com/" + projectId;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/" + projectId,
                        ValidateAudience = true,
                        ValidAudience = projectId,
                        ValidateLifetime = true,
                    };
                });

            services.AddRateLimiterEnd();
        }

        /// <summary>
        /// Configures the specified application. This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="logger">The logger.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseSwaggerServices();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
            });

            //Taking care of the database
            SeedData.Initialize(app.ApplicationServices);
            logger.LogInformation("App started");
        }
    }
}
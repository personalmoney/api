using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.Helpers
{
    internal class SeedData
    {
        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (IServiceScope serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // auto migration
                context.Database.Migrate();
            }
        }
    }
}
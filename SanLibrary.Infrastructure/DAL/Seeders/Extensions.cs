using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Infrastructure.DAL.Seeders
{
    public static class Extensions
    {
        public static IApplicationBuilder UseSeeder(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
                seeder.Seed();
            }

            return app;
        }
    }
}

 using System;
 using System.Linq;
 using Microsoft.AspNetCore.Builder;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.DependencyInjection;
 using Microsoft.IdentityModel.Tokens;
 using PlatformServices.Models;

 namespace PlatformServices.Data
{
    public  static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform(){Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                     new Platform(){ Name = "SQL Sever Express", Publisher = "Microsoft", Cost = "Free" },
                     new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {

                Console.WriteLine("--> We already have data");
            }

        }
    }
}
 
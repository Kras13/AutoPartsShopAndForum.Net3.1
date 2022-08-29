namespace AutoPartsShopAndForum.Infrastructure
{
    using AutoPartsShopAndForum.Data;
    using AutoPartsShopAndForum.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;
    using System.Linq;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            Task.Run(async () =>
                {
                    using (
                        IServiceScope serviceScope = app.ApplicationServices
                            .GetRequiredService<IServiceScopeFactory>()
                            .CreateScope())
                    {
                        ApplicationDbContext dbContext = serviceScope.ServiceProvider
                            .GetService<ApplicationDbContext>();
                        dbContext.Database.Migrate();

                        await SeedTowns(serviceScope.ServiceProvider);
                        await SeedAdministrator(serviceScope.ServiceProvider);
                        await SeedCategories(serviceScope.ServiceProvider);

                        await dbContext.SaveChangesAsync();
                    }
                });

            return app;
        }

        private static async Task SeedCategories(IServiceProvider serviceProvider)
        {
            string[] categories = { "Oils and liquids", "Filters" };

            var context = serviceProvider.GetService<ApplicationDbContext>();

            Category[] savedCategories = await context.Categories.ToArrayAsync();

            foreach (var category in categories)
            {
                if (savedCategories.Any(c => c.Name == category))
                {
                    continue;
                }

                await context.Categories.AddAsync(new Category()
                {
                    Name = category
                });
            }
        }

        private static async Task SeedTowns(IServiceProvider serviceProvider)
        {
            string[] towns = { "Stara Zagora", "Sofia", "Varna", "Plovdiv", "Burgas", "Pleven" };

            var context = serviceProvider.GetService<ApplicationDbContext>();

            Town[] savedTowns = await context.Towns.ToArrayAsync();

            foreach (var town in towns)
            {
                if (savedTowns.Any(t => t.Name == town))
                {
                    continue;
                }

                await context.Towns.AddAsync(new Town() { Name = town });
            }
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            bool adminRoleExists = await roleManager
                .RoleExistsAsync(Data.Models.Constants.Role.Administrator);

            if (adminRoleExists)
            {
                return;
            }

            IdentityResult result =
                await roleManager.CreateAsync(new IdentityRole(Data.Models.Constants.Role.Administrator));

            if (result.Succeeded)
            {
                User user = new User()
                {
                    UserName = "admin",
                    FirstName = "Admin",
                    LastName = "Adminchev",
                    EGN = "0112222333",
                    Email = "admin@abv.bg",
                    TownId = 1
                };

                await userManager.CreateAsync(user, "admin123");

                await userManager.AddToRoleAsync(user, Data.Models.Constants.Role.Administrator);
            }
        }
    }
}

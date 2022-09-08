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
                        await dbContext.SaveChangesAsync();

                        await SeedAdministrator(serviceScope.ServiceProvider);
                        await dbContext.SaveChangesAsync();

                        await SeedSeller(serviceScope.ServiceProvider);
                        await dbContext.SaveChangesAsync();

                        await SeedCategories(serviceScope.ServiceProvider);
                        await dbContext.SaveChangesAsync();

                        await SeedSubcategories(serviceScope.ServiceProvider);
                        await dbContext.SaveChangesAsync();
                    }
                });

            return app;
        }

        private static async Task SeedSubcategories(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            var categories = context.Categories.ToArray();

            Subcategory[] subcategories =
                {
                    new Subcategory(){Name = "Oils", CategoryId = categories[0].Id},
                    new Subcategory(){Name = "Antifreeze", CategoryId = categories[0].Id},
                    new Subcategory(){Name = "Oil filters", CategoryId = categories[1].Id},
                    new Subcategory(){Name = "Air filters", CategoryId = categories[1].Id},
                    new Subcategory(){Name = "Front window", CategoryId = categories[2].Id},
                    new Subcategory(){Name = "Back window", CategoryId = categories[2].Id},
                };

            Subcategory[] savedSubcategories = await context.Subcategories.ToArrayAsync();

            foreach (var subCat in subcategories)
            {
                if (savedSubcategories.Any(c => c.Name == subCat.Name))
                {
                    continue;
                }

                await context.Subcategories.AddAsync(new Subcategory()
                {
                    Name = subCat.Name,
                    CategoryId = subCat.CategoryId
                });
            }

        }

        private static async Task SeedCategories(IServiceProvider serviceProvider)
        {
            Category[] categories =
                {
                new Category() {Name = "Oils and liquids", ImageUrl = "https://www.autopower.bg/images/categories/%D0%9C%D0%B0%D1%81%D0%BB%D0%B0%20%D0%B8%20%D1%82%D0%B5%D1%87%D0%BD%D0%BE%D1%81%D1%82%D0%B8.jpg"},
                new Category() {Name = "Filters", ImageUrl = "https://www.autopower.bg/images/categories/%D0%A4%D0%B8%D0%BB%D1%82%D1%80%D0%B8.jpg" },
                new Category() {Name = "Windows cleaning", ImageUrl = "https://www.autopower.bg/images/categories/%D0%9F%D0%BE%D1%87%D0%B8%D1%81%D1%82%D0%B2%D0%B0%D0%BD%D0%B5%20%D0%BD%D0%B0%20%D1%81%D1%82%D1%8A%D0%BA%D0%BB%D0%B0%D1%82%D0%B0.jpg" }
            };

            var context = serviceProvider.GetService<ApplicationDbContext>();

            Category[] savedCategories = await context.Categories.ToArrayAsync();

            foreach (var category in categories)
            {
                if (savedCategories.Any(c => c.Name == category.Name))
                {
                    continue;
                }

                await context.Categories.AddAsync(new Category()
                {
                    Name = category.Name,
                    ImageUrl = category.ImageUrl
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
                string adminEmail = "admin@abv.bg";
                string adminPassword = "admin123";

                User user = new User()
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FirstName = "Admin",
                    LastName = "Adminchev",
                    EGN = "0112222333",
                    TownId = 1
                };

                await userManager.CreateAsync(user, adminPassword);

                await userManager.AddToRoleAsync(user, Data.Models.Constants.Role.Administrator);
            }
        }

        private static async Task SeedSeller(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            bool sellerRoleExists = await roleManager
                .RoleExistsAsync(Data.Models.Constants.Role.Seller);

            if (sellerRoleExists)
            {
                return;
            }

            IdentityResult result =
                await roleManager.CreateAsync(new IdentityRole(Data.Models.Constants.Role.Seller));

            if (result.Succeeded)
            {
                string sellerEmail = "seller@abv.bg";
                string sellerPassword = "123456";

                var user = new User()
                {
                    Email = sellerEmail,
                    UserName = sellerEmail,
                    FirstName = "Seller",
                    LastName = "Sellerov",
                    TownId = 2,
                    EGN = "2222222222"
                };

                await userManager.CreateAsync(user, sellerPassword);
                await userManager.AddToRoleAsync(user, Data.Models.Constants.Role.Seller);
            }
        }
    }
}

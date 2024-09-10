using BookShoppingSystemMVC.Constants;
using BookShoppingSystemMVC.Data;
using BookShoppingSystemMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookShoppingSystemMVC.Infrastructure
{
    public static class AppBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            var scopedServices = app.ApplicationServices.CreateScope();
            var data = scopedServices.ServiceProvider.GetService<BookSystemDbContext>();

            data.Database.Migrate();

            SeedCategories(data);
            await SeedDefaultData(scopedServices.ServiceProvider);

            return app;
        }


        private static void SeedCategories(BookSystemDbContext data)
        {
            if (data.Genres.Any())
            {
                return;
            }

            data.Genres.AddRange(new[]
            {
                new Genre { GenreName = "Adventure"},
                new Genre { GenreName = "Mystery"},
                new Genre { GenreName = "Comics"},
                new Genre { GenreName = "Thriller"},
                new Genre { GenreName = "Biography"},
                new Genre { GenreName = "Horror"},
                new Genre { GenreName = "Cooking"},
                new Genre { GenreName = "Science"},
                new Genre { GenreName = "Psychology"},
            });

            data.SaveChanges();
        }

        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,

            };

            var isUserExists = await userManager.FindByEmailAsync(admin.Email);

            if (isUserExists is null)
            {
                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
    }
}

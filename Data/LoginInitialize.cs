using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MailroomApplication.Models;
using Microsoft.AspNetCore.Identity;
using MvcPackage.Data;

namespace MailroomApplication.Data
{
    public class LoginInitialize
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<User> userManager)
        {
            using(var context = new LoginDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<LoginDbContext>>()))
                {
                    context.Database.EnsureCreated();

                    if (context.Users.Any())
                    {
                        return;
                    }

                    var user = new User
                    {
                        UserName = "alice@wtamu.edu",
                        Email = "alice@wtamu.edu",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(user, "alice123");

                    var user2 = new User
                    {
                        UserName = "bob@wtamu.edu",
                        Email = "bob@wtamu.edu",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(user2, "bob123");
                }
        }
    }
}

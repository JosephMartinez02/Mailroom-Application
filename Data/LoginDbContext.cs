using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MailroomApplication.Models;

namespace MailroomApplication.Data
{
    public class LoginDbContext : IdentityDbContext<User>
    {
        public LoginDbContext (DbContextOptions<LoginDbContext> options) : base(options)
        {

        }
    }
}
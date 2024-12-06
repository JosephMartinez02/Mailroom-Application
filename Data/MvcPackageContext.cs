using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MailroomApplication.Models;

namespace MvcPackage.Data
{
    public class MvcPackageContext : IdentityDbContext<User>
    {
        public MvcPackageContext (DbContextOptions<MvcPackageContext> options)
            : base(options)
        {
        }

        public DbSet<MailroomApplication.Models.Package> Package { get; set; } = default!;
        public DbSet<MailroomApplication.Models.Resident> Resident {get; set;} = default!;
        public DbSet<MailroomApplication.Models.Staff> Staff {get; set;} = default!;
        public DbSet<MailroomApplication.Models.Unknown> Unknown {get; set;} = default!;
    }
}

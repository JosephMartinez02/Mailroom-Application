using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MailroomApplication.Models;

namespace MvcPackage.Data
{
    public class MvcPackageContext : DbContext
    {
        public MvcPackageContext (DbContextOptions<MvcPackageContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResidentPackage>().HasKey(e => new {e.residentID, e.packageID});
            modelBuilder.Entity<Package>()
                .HasMany(e => e.Unknowns)
                .WithOne(e => e.Package)
                .HasForeignKey(e => e.packageID)
                .IsRequired();
            modelBuilder.Entity<Resident>()
                .HasMany(e => e.Packages)
                .WithOne(e => e.Resident)
                .HasForeignKey(e => e.residentID)
                .IsRequired(false);
        }
        public DbSet<MailroomApplication.Models.Package> Package { get; set; } = default!;
        public DbSet<MailroomApplication.Models.Resident> Resident {get; set;} = default!;
        public DbSet<MailroomApplication.Models.Unknown> Unknown {get; set;} = default!;
        public DbSet<MailroomApplication.Models.ResidentPackage> ResidentPackage {get; set;} = default!;
    }
}

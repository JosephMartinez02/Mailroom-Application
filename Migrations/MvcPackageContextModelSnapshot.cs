﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcPackage.Data;

#nullable disable

namespace MailroomApplication.Migrations
{
    [DbContext(typeof(MvcPackageContext))]
    partial class MvcPackageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("MailroomApplication.Models.Package", b =>
                {
                    b.Property<int>("packageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("checkInDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("checkOutDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("postalService")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("residentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("packageID");

                    b.HasIndex("residentID");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("MailroomApplication.Models.Resident", b =>
                {
                    b.Property<int>("residentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("residentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("unitNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("residentID");

                    b.ToTable("Resident");
                });

            modelBuilder.Entity("MailroomApplication.Models.ResidentPackage", b =>
                {
                    b.Property<int>("residentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("packageID")
                        .HasColumnType("INTEGER");

                    b.HasKey("residentID", "packageID");

                    b.HasIndex("packageID");

                    b.ToTable("ResidentPackage");
                });

            modelBuilder.Entity("MailroomApplication.Models.Unknown", b =>
                {
                    b.Property<int>("unknownID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("packageID")
                        .HasColumnType("INTEGER");

                    b.HasKey("unknownID");

                    b.HasIndex("packageID");

                    b.ToTable("Unknown");
                });

            modelBuilder.Entity("MailroomApplication.Models.Package", b =>
                {
                    b.HasOne("MailroomApplication.Models.Resident", "Resident")
                        .WithMany("Packages")
                        .HasForeignKey("residentID");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("MailroomApplication.Models.ResidentPackage", b =>
                {
                    b.HasOne("MailroomApplication.Models.Package", "Package")
                        .WithMany("ResidentPackages")
                        .HasForeignKey("packageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MailroomApplication.Models.Resident", "Resident")
                        .WithMany("ResidentPackages")
                        .HasForeignKey("residentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("MailroomApplication.Models.Unknown", b =>
                {
                    b.HasOne("MailroomApplication.Models.Package", "Package")
                        .WithMany("Unknowns")
                        .HasForeignKey("packageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
                });

            modelBuilder.Entity("MailroomApplication.Models.Package", b =>
                {
                    b.Navigation("ResidentPackages");

                    b.Navigation("Unknowns");
                });

            modelBuilder.Entity("MailroomApplication.Models.Resident", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("ResidentPackages");
                });
#pragma warning restore 612, 618
        }
    }
}

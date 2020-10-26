﻿// <auto-generated />
using System;
using JobTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobTracker.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20201021011946_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JobTracker.Models.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobTracker.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ContactLastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ContactPhone")
                        .HasColumnType("int");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("ThankYouLetter")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ContactId");

                    b.HasIndex("JobId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("JobTracker.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApplicationLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AppliedAt")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("AppliedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CompanyWebsite")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("JobNote")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("JobStatus")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("JobType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RequiredSkill")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobTracker.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobTracker.Models.Application", b =>
                {
                    b.HasOne("JobTracker.Models.Job", "Job")
                        .WithMany("Applicants")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobTracker.Models.User", "User")
                        .WithMany("AppliedJobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTracker.Models.Contact", b =>
                {
                    b.HasOne("JobTracker.Models.Job", "WorkFor")
                        .WithMany("JobContact")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

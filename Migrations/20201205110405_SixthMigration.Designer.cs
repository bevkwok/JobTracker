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
    [Migration("20201205110405_SixthMigration")]
    partial class SixthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JobTracker.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<string>("ContactLastName")
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<string>("ContactPhone")
                        .HasColumnType("varchar(16) CHARACTER SET utf8mb4")
                        .HasMaxLength(16);

                    b.Property<string>("ContactTitle")
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FromCompany")
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<string>("ThankYouLetter")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("JobTracker.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApplicationLink")
                        .HasColumnName("ApplicationLink")
                        .HasColumnType("LONGTEXT");

                    b.Property<string>("AppliedAt")
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<DateTime>("AppliedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<string>("CompanyWebsite")
                        .HasColumnName("CompanyWebsite")
                        .HasColumnType("LONGTEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("JobNote")
                        .HasColumnName("JobNote")
                        .HasColumnType("LONGTEXT")
                        .HasMaxLength(500);

                    b.Property<string>("JobStatus")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<string>("JobType")
                        .HasColumnType("varchar(46) CHARACTER SET utf8mb4")
                        .HasMaxLength(46);

                    b.Property<string>("RequiredSkill")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("UserId");

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
                        .HasColumnName("Password")
                        .HasColumnType("LONGTEXT");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobTracker.Models.Contact", b =>
                {
                    b.HasOne("JobTracker.Models.Job", null)
                        .WithMany("JobContact")
                        .HasForeignKey("JobId");

                    b.HasOne("JobTracker.Models.User", "Candidate")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTracker.Models.Job", b =>
                {
                    b.HasOne("JobTracker.Models.User", "SavedBy")
                        .WithMany("AppliedJobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

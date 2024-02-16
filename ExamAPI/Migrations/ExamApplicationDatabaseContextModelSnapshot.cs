﻿// <auto-generated />
using System;
using ExamAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamAPI.Migrations
{
    [DbContext(typeof(ExamApplicationDatabaseContext))]
    partial class ExamApplicationDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExamAPI.Models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("QuastionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("QuastionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ExamAPI.Models.Quastion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Quastions");
                });

            modelBuilder.Entity("ExamAPI.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ExamAPI.Models.Answer", b =>
                {
                    b.HasOne("ExamAPI.Models.Quastion", "Quastion")
                        .WithMany("Answers")
                        .HasForeignKey("QuastionId");

                    b.Navigation("Quastion");
                });

            modelBuilder.Entity("ExamAPI.Models.Quastion", b =>
                {
                    b.HasOne("ExamAPI.Models.Subject", "Subject")
                        .WithMany("Quastions")
                        .HasForeignKey("SubjectId");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ExamAPI.Models.Quastion", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("ExamAPI.Models.Subject", b =>
                {
                    b.Navigation("Quastions");
                });
#pragma warning restore 612, 618
        }
    }
}

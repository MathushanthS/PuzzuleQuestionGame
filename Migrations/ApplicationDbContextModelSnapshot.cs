﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PuzzuleQuestion.DbContex;

#nullable disable

namespace PuzzuleQuestion.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PuzzuleQuestion.Model.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Answer1")
                        .HasColumnType("int");

                    b.Property<int>("Answer10")
                        .HasColumnType("int");

                    b.Property<int>("Answer2")
                        .HasColumnType("int");

                    b.Property<int>("Answer3")
                        .HasColumnType("int");

                    b.Property<int>("Answer4")
                        .HasColumnType("int");

                    b.Property<int>("Answer5")
                        .HasColumnType("int");

                    b.Property<int>("Answer6")
                        .HasColumnType("int");

                    b.Property<int>("Answer7")
                        .HasColumnType("int");

                    b.Property<int>("Answer8")
                        .HasColumnType("int");

                    b.Property<int>("Answer9")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("PuzzuleQuestion.Model.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("AnswerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PuzzuleQuestion.Model.UserModel", b =>
                {
                    b.HasOne("PuzzuleQuestion.Model.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId");

                    b.Navigation("Answer");
                });
#pragma warning restore 612, 618
        }
    }
}

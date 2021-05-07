﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAPI.Data;

namespace ProjectAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ProjectAppLibrary.Models.Food", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cuisine")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PictureURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ProjectAppLibrary.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Delivery")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("FoodID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NameofDish")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PictureURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("RecipeID")
                        .HasColumnType("int");

                    b.Property<string>("ratings")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("FoodID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("ProjectAppLibrary.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("FoodID")
                        .HasColumnType("int");

                    b.Property<string>("Ingredients")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("LevelofDifficulty")
                        .HasColumnType("int");

                    b.Property<string>("Method")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PictureURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RecipeName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("FoodID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("ProjectAppLibrary.Models.Restaurant", b =>
                {
                    b.HasOne("ProjectAppLibrary.Models.Food", "Food")
                        .WithMany("Restaurants")
                        .HasForeignKey("FoodID");

                    b.HasOne("ProjectAppLibrary.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID");

                    b.Navigation("Food");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ProjectAppLibrary.Recipe", b =>
                {
                    b.HasOne("ProjectAppLibrary.Models.Food", "Food")
                        .WithMany("Recipes")
                        .HasForeignKey("FoodID");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("ProjectAppLibrary.Models.Food", b =>
                {
                    b.Navigation("Recipes");

                    b.Navigation("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}

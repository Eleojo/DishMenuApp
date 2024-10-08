﻿// <auto-generated />
using System;
using Menu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Menu.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    [Migration("20240817204352_InitialMigrate")]
    partial class InitialMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cbb4b3df-010a-4b4c-9f15-ed41635022b4"),
                            ImageUrl = "https://veenaazmanov.com/wp-content/uploads/2020/04/Classic-Pizza-Margherita1-500x500.jpg",
                            Name = "Margherita",
                            Price = 4000.0
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngredient", b =>
                {
                    b.Property<Guid>("DishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients");

                    b.HasData(
                        new
                        {
                            DishId = new Guid("cbb4b3df-010a-4b4c-9f15-ed41635022b4"),
                            IngredientId = new Guid("d862d160-f543-4254-9e4c-24b9cdda4438")
                        },
                        new
                        {
                            DishId = new Guid("cbb4b3df-010a-4b4c-9f15-ed41635022b4"),
                            IngredientId = new Guid("b6b24b9f-66a3-45a9-8ce1-0fe81f76325c")
                        });
                });

            modelBuilder.Entity("Menu.Models.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d862d160-f543-4254-9e4c-24b9cdda4438"),
                            Name = "Tomato Sauce"
                        },
                        new
                        {
                            Id = new Guid("b6b24b9f-66a3-45a9-8ce1-0fe81f76325c"),
                            Name = "Mozzarella"
                        });
                });

            modelBuilder.Entity("Menu.Models.DishIngredient", b =>
                {
                    b.HasOne("Menu.Models.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Menu.Models.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Menu.Models.Dish", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("Menu.Models.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}

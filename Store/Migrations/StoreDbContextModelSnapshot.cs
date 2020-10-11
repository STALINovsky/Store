﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data;

namespace Store.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Store.Models.CartLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("Store.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Shipped")
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Store.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Watersports",
                            Description = "A boat for one person",
                            Name = "Kayak",
                            Price = 275m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Watersports",
                            Description = "Protective and fashionable",
                            Name = "Lifejacket",
                            Price = 48.95m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Soccer",
                            Description = "Give your playing field a professional touch",
                            Name = "Corner Flags",
                            Price = 34.95m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Soccer",
                            Description = "Flat-packed 35,000-seat stadium",
                            Name = "Stadium",
                            Price = 79500m
                        },
                        new
                        {
                            Id = 5,
                            Category = "Chess",
                            Description = "Improve brain efficiency by 75%",
                            Name = "Thinking Cap",
                            Price = 16m
                        },
                        new
                        {
                            Id = 6,
                            Category = "Chess",
                            Description = "Secretly give your opponent a disadvantage",
                            Name = "Unsteady Chair",
                            Price = 29.95m
                        },
                        new
                        {
                            Id = 7,
                            Category = "Chess",
                            Description = "A fun game for the family",
                            Name = "Human Chess Board",
                            Price = 75m
                        },
                        new
                        {
                            Id = 8,
                            Category = "Chess",
                            Description = "Gold-plated, diamond-studded King",
                            Name = "Bling-Bling King",
                            Price = 1200m
                        },
                        new
                        {
                            Id = 9,
                            Category = "Soccer",
                            Description = "FIFA-approved size and weight",
                            Name = "Soccer Ball",
                            Price = 19.50m
                        });
                });

            modelBuilder.Entity("Store.Models.CartLine", b =>
                {
                    b.HasOne("Store.Models.Order", null)
                        .WithMany("Lines")
                        .HasForeignKey("OrderId");

                    b.HasOne("Store.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SugarShark.Infrastructure;

#nullable disable

namespace SugarShark.Infrastructure.Migrations
{
    [DbContext(typeof(SugarSharkDbContext))]
    [Migration("20230603044143_v1.4")]
    partial class v14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SugarShark.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidityEndDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            UserId = 2,
                            ValidityEndDate = new DateTime(2023, 6, 5, 0, 41, 43, 772, DateTimeKind.Local).AddTicks(86)
                        },
                        new
                        {
                            Id = 4,
                            UserId = 1,
                            ValidityEndDate = new DateTime(2023, 6, 5, 0, 41, 43, 772, DateTimeKind.Local).AddTicks(145)
                        });
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId", "CartId")
                        .IsUnique();

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CartId = 2,
                            ProductId = 11,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            CartId = 2,
                            ProductId = 12,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            CartId = 2,
                            ProductId = 13,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 4,
                            CartId = 4,
                            ProductId = 12,
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 11,
                            Description = " Baby shark sugar cookies",
                            Image = "cookies-image-base64",
                            Name = "Cookies",
                            Price = 30.0,
                            ProductTypeId = 1,
                            Stock = 20
                        },
                        new
                        {
                            Id = 12,
                            Description = " Baby shark sugar Cakesicles",
                            Image = "Cakesicles-image-base64",
                            Name = "Cakesicles",
                            Price = 30.0,
                            ProductTypeId = 1,
                            Stock = 20
                        },
                        new
                        {
                            Id = 13,
                            Description = " Baby shark sugar cookies",
                            Image = "cookies-image-base64",
                            Name = "Cookies",
                            Price = 50.0,
                            ProductTypeId = 2,
                            Stock = 10
                        },
                        new
                        {
                            Id = 14,
                            Description = " Baby shark sugar cookies",
                            Image = "cookies-image-base64",
                            Name = "Cookies",
                            Price = 5.0,
                            ProductTypeId = 3,
                            Stock = 2
                        },
                        new
                        {
                            Id = 15,
                            Description = " shark sugar Cupcake",
                            Image = "Cupcake-image-base64",
                            Name = "Cupcake",
                            Price = 40.0,
                            ProductTypeId = 3,
                            Stock = 60
                        },
                        new
                        {
                            Id = 16,
                            Description = " Baby shark sugar Sprinkles",
                            Image = "Sprinkles-image-base64",
                            Name = "Sprinkles",
                            Price = 10.0,
                            ProductTypeId = 3,
                            Stock = 200
                        });
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AMBER"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DARK"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CLEAR"
                        });
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("SugarShark.Domain.Entities.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.Order", b =>
                {
                    b.HasOne("SugarShark.Domain.Entities.Address", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliveryAddress");
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.Product", b =>
                {
                    b.HasOne("SugarShark.Domain.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("SugarShark.Domain.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}

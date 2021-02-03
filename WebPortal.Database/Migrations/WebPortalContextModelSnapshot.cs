﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPortal.Database.Models;

namespace WebPortal.Database.Migrations
{
    [DbContext(typeof(WebPortalContext))]
    partial class WebPortalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("WebPortal.Database.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebPortal.Database.Models.OrderComments", b =>
                {
                    b.Property<int>("OrderCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderCommentId");

                    b.ToTable("OrderComments");
                });

            modelBuilder.Entity("WebPortal.Database.Models.OrderStatuses", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("OrdersStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "New"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "Paid"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "Shipped"
                        },
                        new
                        {
                            StatusId = 4,
                            StatusName = "Delivered"
                        },
                        new
                        {
                            StatusId = 5,
                            StatusName = "Closed"
                        });
                });

            modelBuilder.Entity("WebPortal.Database.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId1")
                        .HasColumnType("int");

                    b.Property<float?>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<int?>("OrderCommentsOrderCommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderStatusesStatusId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("OrderCommentsOrderCommentId");

                    b.HasIndex("OrderStatusesStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebPortal.Database.Models.OrdersProducts", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("WebPortal.Database.Models.ProductCategories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Food"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Electronics"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Furniture"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Shoes"
                        });
                });

            modelBuilder.Entity("WebPortal.Database.Models.ProductDescriptions", b =>
                {
                    b.Property<int>("ProductDescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductDescriptionId");

                    b.ToTable("ProductDescriptions");
                });

            modelBuilder.Entity("WebPortal.Database.Models.ProductSizes", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SizeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SizeId");

                    b.ToTable("ProductSizes");

                    b.HasData(
                        new
                        {
                            SizeId = 1,
                            SizeName = "Small"
                        },
                        new
                        {
                            SizeId = 2,
                            SizeName = "Medium"
                        },
                        new
                        {
                            SizeId = 3,
                            SizeName = "Large"
                        });
                });

            modelBuilder.Entity("WebPortal.Database.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("ProductCategoriesCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductDescriptionId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductSizesSizeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductCategoriesCategoryId");

                    b.HasIndex("ProductDescriptionId");

                    b.HasIndex("ProductSizesSizeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebPortal.Database.Models.Orders", b =>
                {
                    b.HasOne("WebPortal.Database.Models.Customers", "CustomerId")
                        .WithMany()
                        .HasForeignKey("CustomerId1");

                    b.HasOne("WebPortal.Database.Models.OrderComments", "OrderComments")
                        .WithMany()
                        .HasForeignKey("OrderCommentsOrderCommentId");

                    b.HasOne("WebPortal.Database.Models.OrderStatuses", "OrderStatuses")
                        .WithMany()
                        .HasForeignKey("OrderStatusesStatusId");

                    b.Navigation("CustomerId");

                    b.Navigation("OrderComments");

                    b.Navigation("OrderStatuses");
                });

            modelBuilder.Entity("WebPortal.Database.Models.OrdersProducts", b =>
                {
                    b.HasOne("WebPortal.Database.Models.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("WebPortal.Database.Models.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebPortal.Database.Models.Products", b =>
                {
                    b.HasOne("WebPortal.Database.Models.ProductCategories", "ProductCategories")
                        .WithMany()
                        .HasForeignKey("ProductCategoriesCategoryId");

                    b.HasOne("WebPortal.Database.Models.ProductDescriptions", "ProductDescription")
                        .WithMany()
                        .HasForeignKey("ProductDescriptionId");

                    b.HasOne("WebPortal.Database.Models.ProductSizes", "ProductSizes")
                        .WithMany()
                        .HasForeignKey("ProductSizesSizeId");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductDescription");

                    b.Navigation("ProductSizes");
                });
#pragma warning restore 612, 618
        }
    }
}

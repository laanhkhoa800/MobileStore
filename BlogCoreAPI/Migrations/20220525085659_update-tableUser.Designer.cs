﻿// <auto-generated />
using System;
using BlogCoreAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogCoreAPI.Migrations
{
    [DbContext(typeof(ApContext))]
    [Migration("20220525085659_update-tableUser")]
    partial class updatetableUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BlogCoreAPI.Model.DetailOrder", b =>
                {
                    b.Property<int>("DetailOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SubProductId")
                        .HasColumnType("int");

                    b.HasKey("DetailOrderId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SubProductId");

                    b.ToTable("DetailOrder");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StatusOrderId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("StatusOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(20000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image5")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageMain")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSecon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double?>("PriceSales")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("View")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("ProductId");

                    b.HasIndex("StyleId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.StatusOrder", b =>
                {
                    b.Property<int>("StatusOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StatusOrderId");

                    b.ToTable("StatusOrder");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.StatusUser", b =>
                {
                    b.Property<int>("StatusUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StatusUserId");

                    b.ToTable("StatusUser");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StyleId");

                    b.ToTable("Style");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.SubProduct", b =>
                {
                    b.Property<int>("SubProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("SubProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StatusId");

                    b.ToTable("SubProduct");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passwork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StatusUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("StatusUserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.DetailOrder", b =>
                {
                    b.HasOne("BlogCoreAPI.Model.Order", "Order")
                        .WithMany("DetailOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BlogCoreAPI.Model.SubProduct", "SubProduct")
                        .WithMany("DetailOrders")
                        .HasForeignKey("SubProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("SubProduct");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Order", b =>
                {
                    b.HasOne("BlogCoreAPI.Model.StatusOrder", "StatusOrder")
                        .WithMany("Orders")
                        .HasForeignKey("StatusOrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BlogCoreAPI.Model.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("StatusOrder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Product", b =>
                {
                    b.HasOne("BlogCoreAPI.Model.Style", "Style")
                        .WithMany("Products")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Style");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.SubProduct", b =>
                {
                    b.HasOne("BlogCoreAPI.Model.Product", "Product")
                        .WithMany("SubProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BlogCoreAPI.Model.Status", "Status")
                        .WithMany("SubProducts")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.User", b =>
                {
                    b.HasOne("BlogCoreAPI.Model.StatusUser", "StatusUser")
                        .WithMany("Users")
                        .HasForeignKey("StatusUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("StatusUser");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Order", b =>
                {
                    b.Navigation("DetailOrders");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Product", b =>
                {
                    b.Navigation("SubProducts");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Status", b =>
                {
                    b.Navigation("SubProducts");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.StatusOrder", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.StatusUser", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.Style", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.SubProduct", b =>
                {
                    b.Navigation("DetailOrders");
                });

            modelBuilder.Entity("BlogCoreAPI.Model.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VietSacBackend._3.Repository.Data;

#nullable disable

namespace VietSacBackend.Migrations
{
    [DbContext(typeof(VietSacContext))]
    partial class VietSacContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.CartEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("order_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("price")
                        .HasColumnType("decimal(38,4)");

                    b.Property<string>("product_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("quantity")
                        .HasColumnType("decimal(38,4)");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("order_id");

                    b.HasIndex("product_id");

                    b.HasIndex("user_id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.CategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categoryEntities");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.OrderEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("orderStatus")
                        .HasColumnType("int");

                    b.Property<decimal?>("orderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("order_date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("paymentMenthod_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("shippingMenthod_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("paymentMenthod_id");

                    b.HasIndex("shippingMenthod_id");

                    b.HasIndex("user_id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.PaymentMenthodEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMenthod");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.ProductEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("category_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("discount")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("price")
                        .HasColumnType("decimal(38,4)");

                    b.Property<decimal?>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("category_id");

                    b.ToTable("productEntities");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.RoleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("role_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("roleEntities");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.ShippingMethodEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("shippingMethodEntities");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("role_id");

                    b.ToTable("userEntities");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.UserRefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ExpireTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("JwtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastUpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isUsed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("UserRefreshToken");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.CartEntity", b =>
                {
                    b.HasOne("VietSacBackend._3.Repository.Data.OrderEntity", "Order")
                        .WithMany("Carts")
                        .HasForeignKey("order_id");

                    b.HasOne("VietSacBackend._3.Repository.Data.ProductEntity", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VietSacBackend._3.Repository.Data.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.OrderEntity", b =>
                {
                    b.HasOne("VietSacBackend._3.Repository.Data.PaymentMenthodEntity", "paymentMenthod")
                        .WithMany()
                        .HasForeignKey("paymentMenthod_id");

                    b.HasOne("VietSacBackend._3.Repository.Data.ShippingMethodEntity", "shippingMenthod")
                        .WithMany()
                        .HasForeignKey("shippingMenthod_id");

                    b.HasOne("VietSacBackend._3.Repository.Data.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("paymentMenthod");

                    b.Navigation("shippingMenthod");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.ProductEntity", b =>
                {
                    b.HasOne("VietSacBackend._3.Repository.Data.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.UserEntity", b =>
                {
                    b.HasOne("VietSacBackend._3.Repository.Data.RoleEntity", "Role")
                        .WithMany("UserEntities")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.UserRefreshToken", b =>
                {
                    b.HasOne("VietSacBackend._3.Repository.Data.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.OrderEntity", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.ProductEntity", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("VietSacBackend._3.Repository.Data.RoleEntity", b =>
                {
                    b.Navigation("UserEntities");
                });
#pragma warning restore 612, 618
        }
    }
}

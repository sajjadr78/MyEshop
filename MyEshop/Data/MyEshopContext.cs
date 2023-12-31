﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEshop.Models;

namespace MyEshop.Data
{
    public class MyEshopContext : DbContext
    {
        public MyEshopContext(DbContextOptions<MyEshopContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>()
                .HasKey(t => new { t.ProductId, t.CategoryId });

            //modelBuilder.Entity<Product>(
            //    p =>
            //    {
            //        p.HasKey(w => w.Id);
            //        p.OwnsOne<Item>(w => w.Item);
            //        p.HasOne<Item>(w => w.Item)
            //            .WithOne(w => w.Product)
            //            .HasForeignKey<Item>(w => w.Id);
            //    }
            //);

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });

            #region Seed Data Category

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "Asp.Net Core",
                Description = "Asp.Net Core 3"
            },
                new Category()
                {
                    Id = 2,
                    Name = "لباس ورزشی",
                    Description = "گروه لباس ورزشی"
                },
                new Category()
                {
                    Id = 3,
                    Name = "ساعت مچی",
                    Description = "ساعت مچی"
                },
                new Category()
                {
                    Id = 4,
                    Name = "لوازم منزل",
                    Description = "لوازم منزل"
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    Price = 854.0M,
                    QuantityInStock = 5
                },
            new Item()
            {
                Id = 2,
                Price = 3302.0M,
                QuantityInStock = 8
            },
            new Item()
            {
                Id = 3,
                Price = 2500,
                QuantityInStock = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemId = 1,
                Name = "آموزش Asp.Net Core 3 پروژه محور",
                Description =
                        "آموزش Asp.Net Core 3 پروژه محور ASP.NET Core بر پایه‌ی NET Core.استوار است و نگارشی از NET.محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند.ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری(Cloud) هم بتوانند میزبانی(Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET.را افزایش داده است.به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.",
                FileExtension = ".jpg"
            },
                new Product()
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "آموزش Blazor از مقدماتی تا پیشرفته",
                    Description =
                        "در سال های گذشته ، کمپانی مایکروسافت با معرفی تکنولوژی های جدید و حرفه ای در زمینه های مختلف ، عرصه را برای سایر کمپانی ها تنگ تر کرده است. اخیرا این غول فناوری با معرفی فریم ورک های ASP.NET Core و همینطور Blazor قدرت خود در زمینه ی وب را به اثبات رسانده است.",
                    FileExtension = ".jpg"
                },
                new Product()
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "آموزش اپلیکیشن های وب پیش رونده ( PWA )",
                    Description = "آموزش اپلیکیشن های وب پیش رونده ( PWA ) آموزش PWA از مقدماتی تا پیشرفته وب اپلیکیشن‌های پیش رونده(PWA) نسل جدید اپلیکیشن‌های تحت وب هستند که می‌توانند آینده‌ی اپلیکیشن‌های موبایل را متحول کنند.در این دوره به طور جامع به بررسی آن‌ها خواهیم پرداخت. مزایا و فاکتور هایی که یک وب اپلیکیشن دارا می باشد به صورت زیر می باشد : ریسپانسیو :  رکن اصلی سایت برای PWA ریسپانسیو بودن اپلیکیشن هستش که برای صفحه نمایش کاربران مختلف موبایل و تبلت خود را وفق دهند.",
                    FileExtension = ".jpg"
                });

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 3 }
                );

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = 1,
                    RegisterDate = DateTime.Now,
                    Email = "stajmir78@gmail.com",
                    Password = "123",
                    IsAdmin = true
                });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    CreateDate = DateTime.Now,
                    IsFinaly = false,
                    OrderId = 1,
                    UserId = 1
                });

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Count = 1,
                    OrderId = 1,
                    Price = 555,
                    ProductId = 1,
                    DetailId = 1
                });

            #endregion
base.OnModelCreating(modelBuilder);
        }
    }
}

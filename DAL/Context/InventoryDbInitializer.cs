using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public static class InventoryDbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>().HasData(
                new Dictionary()
                {
                    Id = 1,
                    Name = "მარკეტი"
                },
                new Dictionary()
                {
                    Id = 2,
                    Name = "სუპერმარკეტი"
                },
                new Dictionary()
                {
                    Id = 3,
                    Name = "ჰიპერმარკეტი"
                }
            );

            modelBuilder.Entity<Shop>().HasData(
                new Shop()
                {
                    Id = 1,
                    Name = "ზუმერი",
                    Address = "ქ.თბილისი, წერეთლის გამზ. N1",
                    TypeId = 1
                },
                new Shop()
                {
                    Id = 2,
                    Name = "ალტა",
                    Address = "ქ. თბილისი, ქავთარაძის 1 (სითი მოლი)",
                    TypeId = 3
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Code = "APPLE159",
                    Name = "Apple iPhone 12 Pro Max",
                    Description = "შეიძინეთ 2020 წლის საუკეთესო მოდელი - Apple iPhone 12 Pro Max Single Sim 512GB Pacific Blue",
                    Brand = "Apple",
                    ImportDate = new DateTime(2020, 01, 15)
                },
                new Product()
                {
                    Id = 2,
                    Code = "SAMSUNG127",
                    Name = "Samsung Galaxy S20+",
                    Description = "შეიძინეთ Samsung G986FD Galaxy S20+ Dual Sim 12GB RAM",
                    Brand = "Samsung",
                    ImportDate = new DateTime(2019, 07, 23)
                },
                new Product()
                {
                    Id = 3,
                    Code = "ONEPLUS8",
                    Name = "OnePlus 8T",
                    Description = "შეიძინეთ შეღავათიან ფასად OnePlus 8T Dual Sim 8GB RAM 128GB 5G Global Version Lunar Silver",
                    Brand = "OnePlus",
                    ImportDate = new DateTime(2021, 01, 07)
                }
            );
        }
    }
}

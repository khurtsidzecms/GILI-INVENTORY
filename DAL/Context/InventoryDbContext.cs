using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class InventoryDbContext : IdentityDbContext<User>
    {
        public InventoryDbContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Product> Product { get; set; }

        public DbSet<Shop> Shop { get; set; }

        public DbSet<ShopProduct> ShopProducts { get; set; }

        public DbSet<Dictionary> Dictionaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .HasMaxLength(10)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Brand)
                .HasMaxLength(25)
                .IsRequired(true);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Address)
                .HasMaxLength(100)
                .IsRequired(true);

            modelBuilder.Entity<Shop>()
                .HasOne(e => e.Type)
                .WithMany(e => e.ShopTypes)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShopProduct>()
                .HasKey(e => new { e.ShopId, e.ProductId });

            modelBuilder.Entity<ShopProduct>()
                .HasOne(e => e.Shop)
                .WithMany(e => e.ShopProducts)
                .HasForeignKey(e => e.ShopId);

            modelBuilder.Entity<ShopProduct>()
                .HasOne(e => e.Product)
                .WithMany(e => e.ShopProducts)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Seed();
        }
    }
}

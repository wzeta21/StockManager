using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManager.Data.Entities;

namespace StockManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Id)
                    .HasName("idx_product")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<Category>(entity =>{
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Id)
                    .HasName("idx_category")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasMany(m => m.Products)
                    .WithOne(o => o.Categories)
                    .HasForeignKey(f => f.CategoryId)
                    .HasConstraintName("fk_product_categories");
            });

            builder.Entity<Brand>(entity =>{
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Id)
                    .HasName("idx_brand")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasMany(m => m.Products)
                    .WithOne(o => o.Brands)
                    .HasForeignKey(f => f.CategoryId)
                    .HasConstraintName("fk_product_brands");
            });
        }
    }
}

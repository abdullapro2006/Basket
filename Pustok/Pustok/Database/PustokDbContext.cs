﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pustok.Contracts;
using Pustok.Database.DomainModels;

namespace Pustok.Database;

public class PustokDbContext : DbContext
{
    public PustokDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

        modelBuilder
            .Entity<ProductColor>()
            .ToTable("ProductColors")
            .HasKey(x => new { x.ProductId, x.ColorId });

        modelBuilder
            .Entity<ProductSize>()
            .ToTable("ProductSizes")
            .HasKey(x => new { x.ProductId, x.SizeId });


        modelBuilder
          .Entity<Size>()
          .ToTable("Sizes")
          .HasData(
            new Size
            {
                Id = -1,
                Name = "S",
            },
            new Size
            {
                Id = -2,
                Name = "XS",
            },
            new Size
            {
                Id = -3,
                Name = "XXS",
            },
            new Size
            {
                Id = -4,
                Name = "L",
            },
            new Size
            {
                Id = -5,
                Name = "XL",
            });

        modelBuilder
            .Entity<Color>()
            .HasData(
                new Color
                {
                    Id = -1,
                    Name = "Red",
                },
                new Color
                {
                    Id = -2,
                    Name = "Green",
                },
                new Color
                {
                    Id = -3,
                    Name = "Blue",
                },
                new Color
                {
                    Id = -4,
                    Name = "Black",
                }
            );

        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = -1,
                    Name = "Admin",
                    LastName = "Admin",
                });


        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BasketProduct> BasketProducts { get; set; }
}

﻿namespace FastFood.Data;

using Microsoft.EntityFrameworkCore;

using Models;
using FastFood.Common.DataConfiguration;

public class FastFoodContext : DbContext
{
    public FastFoodContext()
    {

    }

    public FastFoodContext(DbContextOptions<FastFoodContext> options)
    : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;

    public DbSet<Item> Items { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    public DbSet<Position> Positions { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(ConnectionConfig.ConnectionString)
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ItemId });

        builder.Entity<Position>()
            .HasAlternateKey(p => p.Name);

        builder.Entity<Item>()
            .HasAlternateKey(i => i.Name);
    }
}
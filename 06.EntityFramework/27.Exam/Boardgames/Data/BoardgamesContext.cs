﻿namespace Boardgames.Data;

using Microsoft.EntityFrameworkCore;

using Boardgames.Data.Models;

public class BoardgamesContext : DbContext
{
    public BoardgamesContext()
    { 
    }

    public BoardgamesContext(DbContextOptions options)
        : base(options) 
    {
    }

    public virtual DbSet<Boardgame> Boardgames { get; set; } = null!;

    public virtual DbSet<BoardgameSeller> BoardgamesSellers { get; set; } = null!;

    public virtual DbSet<Creator> Creators { get; set; } = null!;

    public virtual DbSet<Seller> Sellers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(Configuration.ConnectionString)
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoardgameSeller>(e =>
        {
            e.HasKey(k => new { k.BoardgameId, k.SellerId });
        });
    }
}

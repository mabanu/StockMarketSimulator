using Microsoft.EntityFrameworkCore;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Services.AppContext.ContextConfiguration;

namespace StockMarketSimulator.Services.AppContext;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public AppDbContext()
  {
  }

  public virtual DbSet<Nasdaq> NasdaqRates { get; set; } = default!;
  public virtual DbSet<User> Users { get; set; } = default!;

  public virtual DbSet<Order> Orders { get; set; } = default!;

  public virtual DbSet<AccountMovement> AccountMovements { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    var usersSeed = new List<User>
    {
      new("Test", "password"),
      new("Test1", "password1"),
      new("Test2", "password2")
    };

    var ordersSeed = new List<Order>
    {
      new("apple", 10, BuySale.Buy, 100, usersSeed[0].Id),
      new("google", 20, BuySale.Sale, 200, usersSeed[0].Id),
      new("microsoft", 30, BuySale.Buy, 300, usersSeed[0].Id),
      new("apple", 10, BuySale.Sale, 100, usersSeed[1].Id),
      new("google", 20, BuySale.Buy, 200, usersSeed[1].Id),
      new("microsoft", 30, BuySale.Sale, 300, usersSeed[1].Id),
      new("apple", 10, BuySale.Buy, 100, usersSeed[2].Id),
      new("google", 20, BuySale.Sale, 200, usersSeed[2].Id),
      new("microsoft", 30, BuySale.Buy, 300, usersSeed[2].Id)
    };

    var accountMovementsSeed = new List<AccountMovement>
    {
      new(1000, usersSeed[0].Id),
      new(2000, usersSeed[1].Id),
      new(3000, usersSeed[2].Id)
    };

    modelBuilder.ApplyConfiguration(new NasdaqContextConfiguration());
    modelBuilder.Entity<User>().HasData(usersSeed);
    modelBuilder.Entity<Order>().HasData(ordersSeed);
    modelBuilder.Entity<AccountMovement>().HasData(accountMovementsSeed);
  }
}
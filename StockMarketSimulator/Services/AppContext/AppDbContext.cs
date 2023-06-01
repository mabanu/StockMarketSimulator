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

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new NasdaqContextConfiguration());
    modelBuilder.Entity<User>().HasData(
      new List<User>
      {
        new("Test", "password"),
        new("Test1", "password1"),
        new("Test2", "password2")
      });
    modelBuilder.Entity<Order>();
  }
}
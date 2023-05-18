using Microsoft.EntityFrameworkCore;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Services.AppContext.ContextConfiguration;

namespace StockMarketSimulator.Services.AppContext;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Nasdaq> NasdaqRates { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new NasdaqContextConfiguration());
  }
}
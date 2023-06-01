using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using StockMarketSimulator.Repositories.UserRepository;
using StockMarketSimulator.Services.AppContext;

namespace StockMarketSimulatorTest;

public class RepositoryTestWithSqlite
{
  [Fact]
  public void test()
  {
    // TODO fix the source connexion
    var connection =
      "Data Source=C:/Users/maxim/source/post Salt/PGP/StockMarketSimulator/StockMarketSimulator/stock.db";
    var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
    optionBuilder.UseSqlite(connection);

    var appDbContext = new AppDbContext(optionBuilder.Options);

    var userRepo = new UserRepository(appDbContext);

    var result = userRepo.GetUsers();

    result.Count.Should().Be(3);
    result[1].Password.Should().Be("password1");
  }
}
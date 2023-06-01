using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Repositories.UserRepository;
using StockMarketSimulator.Services.AppContext;

namespace StockMarketSimulatorTest;

public class RepositoriesTest
{
  private static List<User> GetFakeUsers()
  {
    return new List<User>
    {
      new("Test", "password"),
      new("Test1", "password1"),
      new("Test2", "password2")
    };
  }

  [Fact]
  public void UserRepositoryMockTest()
  {
    var context = new Mock<AppDbContext>();
    context.Setup<DbSet<User>>(ctx => ctx.Users).ReturnsDbSet(GetFakeUsers());

    var userRepository = new UserRepository(context.Object);
    var users = userRepository.GetUsers();

    users.Count.Should().Be(3);
    users[0].Name.Should().Be("Test");
  }
}
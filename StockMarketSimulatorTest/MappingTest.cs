using FluentAssertions;
using StockMarketSimulator.Contracts.User;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Mapping;

namespace StockMarketSimulatorTest;

public class MappingTest
{
  [Fact]
  public void UserToUserResponseTest()
  {
    var user = new User("Test", "password");
    var dto = UserMapper.UserToUserResponse(user);

    dto.Name.Should().Be("Test");
  }

  [Fact]
  public void UserRequestToUserTest()
  {
    var userRequest = new UserRequest("Test", "password");

    var dto = UserMapper.UserRequestToUser(userRequest);

    dto.Name.Should().Be("Test");
    dto.Password.Should().Be("password");
  }
}
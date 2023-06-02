using Riok.Mapperly.Abstractions;
using StockMarketSimulator.Contracts.User;
using StockMarketSimulator.Entities;

namespace StockMarketSimulator.Mapping;

[Mapper]
public static partial class UserMapper
{
  [MapProperty(nameof(User.Id), nameof(UserResponse.UserId))]
  public static partial UserResponse UserToUserResponse(User user);

  public static partial User UserRequestToUser(UserRequest userRequest);
}
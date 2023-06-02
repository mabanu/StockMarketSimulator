namespace StockMarketSimulator.Contracts.User;

public record UserResponse(
  Guid UserId,
  string Name
);
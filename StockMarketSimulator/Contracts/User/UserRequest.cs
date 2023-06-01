namespace StockMarketSimulator.Contracts.User;

public class UserRequest
{
  public UserRequest(string name, string password)
  {
    Name = name;
    Password = password;
  }

  public string Name { get; private set; } = null!;

  public string Password { get; private set; } = null!;
}
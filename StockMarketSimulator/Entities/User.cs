using System.ComponentModel.DataAnnotations;

namespace StockMarketSimulator.Entities;

public class User
{
  public User()
  {
  }

  public User(string name, string password)
  {
    Name = name;
    Password = password;
  }

  [Key] public Guid Id { get; init; } = Guid.NewGuid();

  [MaxLength(40)] public string Name { get; init; } = null!;

  [MaxLength(40)] public string Password { get; init; } = null!;

  public ICollection<Order> Positions { get; set; }
}
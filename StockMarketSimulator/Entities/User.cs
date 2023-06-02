using System.ComponentModel.DataAnnotations;

namespace StockMarketSimulator.Entities;

public class User
{
  public User()
  {
  }

  public User(string name, string password)
  {
    Id = Guid.NewGuid();
    Name = name;
    Password = password;
    CreatedAt = DateTime.Now;
  }

  [Key] public Guid Id { get; init; }

  [MaxLength(40)] public string Name { get; init; } = null!;

  [MaxLength(40)] public string Password { get; init; } = null!;

  public DateTime CreatedAt { get; init; }

  public List<AccountMovement> Balance { get; set; }

  public ICollection<Order> Positions { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketSimulator.Entities;

public class AccountMovement
{
  public AccountMovement()
  {
  }

  public AccountMovement(float movement, Guid userId)
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.Now;
    Movement = movement;
    UserId = userId;
  }

  [Key] public Guid Id { get; init; }

  public DateTime CreatedAt { get; init; }

  public float Movement { get; init; }

  public Guid UserId { get; init; }

  [ForeignKey("UserId")] public User? User { get; set; }
}
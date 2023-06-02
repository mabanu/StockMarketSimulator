using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketSimulator.Entities;

public class Order
{
  public Order()
  {
  }

  public Order(string stock, int quantity, BuySale buySale, float initialPrice, Guid userId)
  {
    Id = Guid.NewGuid();
    Stock = stock;
    Quantity = quantity;
    BuySale = buySale;
    InitialPrice = initialPrice;
    IsPositionOpen = true;
    UserId = userId;
  }

  [Key] public Guid Id { get; init; }

  [MaxLength(40)] public string Stock { get; init; } = null!;

  public int Quantity { get; init; }

  public BuySale BuySale { get; init; }

  public float InitialPrice { get; init; }

  public float? FinalPrice { get; private set; }

  public bool IsPositionOpen { get; private set; }

  public DateTime CreatedAt { get; init; } = DateTime.Now;

  public DateTime? CloseAt { get; private set; }

  public Guid UserId { get; init; }

  [ForeignKey("UserId")] public User? User { get; set; }

  public void CloseOrder(float finalPrice)
  {
    if (!IsPositionOpen) return;

    CloseAt = DateTime.Now;
    FinalPrice = finalPrice;
    IsPositionOpen = false;
  }
}
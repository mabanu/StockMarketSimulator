using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarketSimulator.Entities;

public class Order
{
  public Order()
  {
  }

  public Order(string stock, int quantity, BuySale buySale)
  {
    Stock = stock;
    Quantity = quantity;
    BuySale = buySale;
  }

  [Key] public Guid Id { get; set; } = Guid.NewGuid();

  [MaxLength(40)] public string Stock { get; set; } = null!;

  public int Quantity { get; set; }

  public BuySale BuySale { get; set; }

  public Guid UserId { get; set; }

  [ForeignKey("UserId")] public User User { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace StockMarketSimulator.Entities;

public class Nasdaq
{
  public Nasdaq()
  {
  }

  public Nasdaq(DateOnly date, float closeLast, string volume, float open, float high, float low)
  {
    Date = date;
    CloseLast = closeLast;
    Volume = volume;
    Open = open;
    High = high;
    Low = low;
  }

  [Key] public Guid Id { get; private set; } = Guid.NewGuid();
  public DateOnly Date { private set; get; }
  public float CloseLast { private set; get; }
  [StringLength(30)] public string Volume { private set; get; }
  public float Open { private set; get; }
  public float High { private set; get; }
  public float Low { private set; get; }
}
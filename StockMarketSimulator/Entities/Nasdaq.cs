using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

  [Key] [JsonPropertyName("id")] public Guid Id { get; private set; } = Guid.NewGuid();

  [JsonPropertyName("date")] public DateOnly Date { private set; get; }

  [JsonPropertyName("closeLast")] public float CloseLast { private set; get; }

  [StringLength(30)]
  [JsonPropertyName("volume")]
  public string Volume { private set; get; } = null!;

  [JsonPropertyName("open")] public float Open { private set; get; }

  [JsonPropertyName("high")] public float High { private set; get; }

  [JsonPropertyName("low")] public float Low { private set; get; }
}
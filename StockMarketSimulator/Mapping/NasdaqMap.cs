using CsvHelper.Configuration;
using StockMarketSimulator.Entities;

namespace StockMarketSimulator.Mapping;

public class NasdaqMap : ClassMap<Nasdaq>
{
  public NasdaqMap()
  {
    Map(n => n.Date).Index(0);
    Map(n => n.CloseLast).Index(1);
    Map(n => n.Volume).Index(2);
    Map(n => n.Open).Index(3);
    Map(n => n.High).Index(4);
    Map(n => n.Low).Index(5);
  }
}
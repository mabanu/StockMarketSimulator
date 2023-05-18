using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Mapping;

namespace StockMarketSimulator.Development;

public class ReadyCSV
{
  public static List<Nasdaq> ReadCsvNasdaq()
  {
    using var reader = new StreamReader("Services/AppContext/Data/Nasdaq2018.csv");
    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
      IncludePrivateMembers = true
    };
    using var csv = new CsvReader(reader, config);
    csv.Context.RegisterClassMap<NasdaqMap>();
    var rec = csv.GetRecords<Nasdaq>();
    return rec.ToList();
  }
}
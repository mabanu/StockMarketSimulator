using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Mapping;

namespace StockMarketSimulator.Services.AppContext.ContextConfiguration;

public class NasdaqContextConfiguration : IEntityTypeConfiguration<Nasdaq>
{
  public void Configure(EntityTypeBuilder<Nasdaq> builder)
  {
    builder.HasData(SeedNasdaqData());
  }


  public List<Nasdaq> SeedNasdaqData()
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
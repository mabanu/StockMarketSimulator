using FluentAssertions;
using StockMarketSimulator.Services.AppContext.ContextConfiguration;
using Xunit.Abstractions;

namespace StockMarketSimulatorTest;

public class UnitTest1
{
  private readonly ITestOutputHelper _testOutputHelper;

  public UnitTest1(ITestOutputHelper testOutputHelper)
  {
    _testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void TestSeedDataSuccessfullyRead()
  {
    var nasdaq = new NasdaqContextConfiguration();
    var read = nasdaq.SeedNasdaqData();
    _testOutputHelper.WriteLine(read.Count.ToString());

    read.Should().HaveCount(1258);
    read[1].Date.Should().Be(new DateOnly(2023, 05, 11));
    read[1257].High.Should().Be(7363.52f);
  }
}
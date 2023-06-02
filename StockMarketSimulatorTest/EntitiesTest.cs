using FluentAssertions;
using StockMarketSimulator.Entities;

namespace StockMarketSimulatorTest;

public class EntitiesTest
{
  [Fact]
  public void Order_Access_Test()
  {
    var order = new Order("APPLE", 11, BuySale.Buy, 100.4f, Guid.NewGuid());

    order.CloseOrder(150.45f);

    order.CloseOrder(10.15f);

    order.FinalPrice.Should().Be(150.45f);
    order.IsPositionOpen.Should().BeFalse();
  }
}
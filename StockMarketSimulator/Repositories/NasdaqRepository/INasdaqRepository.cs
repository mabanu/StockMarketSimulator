using StockMarketSimulator.Entities;

namespace StockMarketSimulator.Repositories.NasdaqRepository;

public interface INasdaqRepository
{
  List<Nasdaq> GetNasdaqRates();
}
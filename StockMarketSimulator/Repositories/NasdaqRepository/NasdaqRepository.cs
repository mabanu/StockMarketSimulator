using StockMarketSimulator.Entities;
using StockMarketSimulator.Services.AppContext;

namespace StockMarketSimulator.Repositories.NasdaqRepository;

public class NasdaqRepository : INasdaqRepository
{
  private readonly AppDbContext _context;

  public NasdaqRepository(AppDbContext context)
  {
    _context = context;
  }

  public List<Nasdaq> GetNasdaqRates()
  {
    var rates = _context.NasdaqRates.ToList();
    return rates;
  }
}
using Microsoft.AspNetCore.Mvc;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Repositories.NasdaqRepository;

namespace StockMarketSimulator.Controllers;

[Route("[controller]")]
[ApiController]
public class NasdaqController : ControllerBase
{
  private readonly INasdaqRepository _nasdaqRepository;

  public NasdaqController(INasdaqRepository nasdaqRepository)
  {
    _nasdaqRepository = nasdaqRepository;
  }

  [HttpGet]
  public ActionResult<List<Nasdaq>> GetNasdaqRates()
  {
    if (_nasdaqRepository == null) return NotFound();

    return Ok(_nasdaqRepository.GetNasdaqRates());
  }
}
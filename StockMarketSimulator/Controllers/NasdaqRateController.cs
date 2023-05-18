using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarketSimulator.Entities;
using StockMarketSimulator.Services.AppContext;

namespace StockMarketSimulator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NasdaqRateController : ControllerBase
{
  private readonly AppDbContext _context;

  public NasdaqRateController(AppDbContext context)
  {
    _context = context;
  }

  // GET: api/NasdaqRateController
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Nasdaq>>> GetNasdaqRates()
  {
    if (_context.NasdaqRates == null) return NotFound();
    return await _context.NasdaqRates.ToListAsync();
  }

  // GET: api/NasdaqRateController/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Nasdaq>> GetNasdaq(Guid id)
  {
    if (_context.NasdaqRates == null) return NotFound();
    var nasdaq = await _context.NasdaqRates.FindAsync(id);

    if (nasdaq == null) return NotFound();

    return nasdaq;
  }

  // PUT: api/NasdaqRateController/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutNasdaq(Guid id, Nasdaq nasdaq)
  {
    if (id != nasdaq.Id) return BadRequest();

    _context.Entry(nasdaq).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!NasdaqExists(id))
        return NotFound();
      throw;
    }

    return NoContent();
  }

  // POST: api/NasdaqRateController
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Nasdaq>> PostNasdaq(Nasdaq nasdaq)
  {
    if (_context.NasdaqRates == null) return Problem("Entity set 'AppDbContext.NasdaqRates'  is null.");
    _context.NasdaqRates.Add(nasdaq);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetNasdaq", new { id = nasdaq.Id }, nasdaq);
  }

  // DELETE: api/NasdaqRateController/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteNasdaq(Guid id)
  {
    if (_context.NasdaqRates == null) return NotFound();
    var nasdaq = await _context.NasdaqRates.FindAsync(id);
    if (nasdaq == null) return NotFound();

    _context.NasdaqRates.Remove(nasdaq);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool NasdaqExists(Guid id)
  {
    return (_context.NasdaqRates?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}
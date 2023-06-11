using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarVisionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarController : ControllerBase
    {
        private readonly DataContext _context;

        public BarController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Bar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarModel>>> GetBars()
        {
            var bars = await _context.Bars.ToListAsync();
            return Ok(bars);
        }

        // GET: api/Bar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BarModel>> GetBar(int id)
        {
            var bar = await _context.Bars.FindAsync(id);

            if (bar == null)
            {
                return NotFound();
            }

            return Ok(bar);
        }

        // GET: api/Bar/owner/{ownerId}
        [HttpGet("owner/{ownerId}")]
        public async Task<ActionResult<IEnumerable<BarModel>>> GetBarsByOwner(int ownerId)
        {
            var bars = await _context.Bars.Where(bar => bar.OwnerId == ownerId).ToListAsync();
            return Ok(bars);
        }

        // POST: api/Bar
        [HttpPost]
        public async Task<ActionResult<BarModel>> CreateBar(BarModel bar)
        {
            _context.Bars.Add(bar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBar), new { id = bar.Id }, bar);
        }

        // PUT: api/Bar/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBar(int id, BarModel bar)
        {
            if (id != bar.Id)
            {
                return BadRequest();
            }

            _context.Entry(bar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Bar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBar(int id)
        {
            var bar = await _context.Bars.FindAsync(id);
            if (bar == null)
            {
                return NotFound();
            }

            _context.Bars.Remove(bar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarExists(int id)
        {
            return _context.Bars.Any(b => b.Id == id);
        }
    }
}

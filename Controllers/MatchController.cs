using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarVisionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly DataContext _context;

        public MatchController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchModel>>> GetMatches()
        {
            var matches = await _context.Matches.ToListAsync();
            return Ok(matches);
        }

        // GET: api/Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchModel>> GetMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // POST: api/Match
        [HttpPost]
        public async Task<ActionResult<MatchModel>> CreateMatch(MatchModel match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
        }

        // PUT: api/Match/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, MatchModel match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(m => m.Id == id);
        }
    }
}

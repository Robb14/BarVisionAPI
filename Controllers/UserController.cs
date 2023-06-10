using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarVisionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel userModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userModel.Username && u.Password == userModel.Password && u.IsActive);
            if (user == null)
            {
                return NotFound("Invalid username or password");
            }

            return Ok(user);
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            if (await _context.Users.AnyAsync(u => u.Username == userModel.Username))
            {
                return BadRequest("Username already exists");
            }

            var user = new UserModel
            {
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                UserType = userModel.UserType,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // GET: api/user/search?query=example
        [HttpGet("search")]
        public IActionResult Search(string query)
        {
            var bars = _context.Bars.Where(b => b.Name.Contains(query) || b.Match.Contains(query) || b.Location.Contains(query)).ToList();
            return Ok(bars);
        }

        // POST: api/user/reserve
        [HttpPost("reserve")]
        public async Task<IActionResult> Reserve([FromBody] ReservationModel reservationModel)
        {
            var user = await _context.Users.FindAsync(reservationModel.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var bar = await _context.Bars.FindAsync(reservationModel.BarId);
            if (bar == null)
            {
                return NotFound("Bar not found");
            }

            var reservation = new ReservationModel
            {
                Date = reservationModel.Date,
                BarId = reservationModel.BarId,
                UserId = reservationModel.UserId,
                AmountOfPeople = reservationModel.AmountOfPeople
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }

        // POST: api/user/review
        [HttpPost("review")]
        public async Task<IActionResult> Review([FromBody] ReviewModel reviewModel)
        {
            var user = await _context.Users.FindAsync(reviewModel.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var bar = await _context.Bars.FindAsync(reviewModel.BarId);
            if (bar == null)
            {
                return NotFound("Bar not found");
            }

            var review = new ReviewModel
            {
                UserId = reviewModel.UserId,
                BarId = reviewModel.BarId,
                Comment = reviewModel.Comment,
                Rating = reviewModel.Rating,
                DateTime = DateTime.Now
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok(review);
        }

        // GET: api/user/menu/{barId}
        [HttpGet("menu/{barId}")]
        public IActionResult GetMenu(int barId)
        {
            var bar = _context.Bars.Include(b => b.Menu).FirstOrDefault(b => b.Id == barId);
            if (bar == null)
            {
                return NotFound("Bar not found");
            }

            return Ok(bar.Menu);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

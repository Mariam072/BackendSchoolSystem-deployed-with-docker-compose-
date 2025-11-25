using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Controller
{
    [ApiController]
    [Route("api/[Controller]")] // Base route: api/supplies
    public class StudentSuppliesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // Constructor: DbContext injected via DI
        public StudentSuppliesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/supplies
        // Returns all supplies that are in stock (QuantityAvailable > 0)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolSupplies>>> GetAllSupplies()
        {
            return Ok(await _context.SchoolSupplies.Where(s => s.QuantityAvaliable > 0).ToListAsync());
        }
        // GET: api/supplies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolSupplies>> GetSuppliesById(int id)
        {
            var supply = await _context.SchoolSupplies.FindAsync(id);

            if (supply == null || supply.QuantityAvaliable <= 0)
            {
                return NotFound("This supply does not exist or is out of stock.");
            }

            return Ok(supply);
        }
        // POST: api/supplies
        [HttpPost]
        public async Task<ActionResult<IEnumerable<SchoolSupplies>>> AddNewSupply([FromBody] SchoolSupplies supply)
        {
            try
            {
                if (supply.Price < 0)
                {
                    return BadRequest("the price can not be negative");
                }
                _context.SchoolSupplies.Add(supply);
                await _context.SaveChangesAsync();
                return Ok("the supply added sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // PUT: api/supplies/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<SchoolSupplies>>> UpdateSupply(int id, [FromBody] SchoolSupplies Updatedsupply)
        {
            try
            {
                var supply = await _context.SchoolSupplies.FindAsync(id);
                if (supply == null)
                {
                    return NotFound("this supply not exist");
                }

                if (Updatedsupply.Price < 0 || Updatedsupply.QuantityAvaliable <= 0)
                {
                    return BadRequest("Price must be postive and quanitiy must be greater than zero");
                }
                supply.ItemName = Updatedsupply.ItemName;
                supply.Price = Updatedsupply.Price;
                supply.QuantityAvaliable = Updatedsupply.QuantityAvaliable;
                await _context.SaveChangesAsync();
                return Ok("the supply added sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        // DELETE: api/supplies/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<SchoolSupplies>>> DeleteSupply(int id)
        {
            try
            {
                var supply = await _context.SchoolSupplies.FindAsync(id);
                if (supply == null)
                {
                    return NotFound();
                }
                _context.SchoolSupplies.Remove(supply);
                await _context.SaveChangesAsync();
                return Ok("supply deleted sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Celebio;

namespace CelebioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TravellersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Travellers
        [HttpGet]
        public IEnumerable<Traveller> Gettraveller()
        {
            return _context.traveller;
        }

        // GET: api/Travellers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraveller([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var traveller = await _context.traveller.FindAsync(id);

            if (traveller == null)
            {
                return NotFound();
            }

            return Ok(traveller);
        }

        // PUT: api/Travellers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraveller([FromRoute] int id, [FromBody] Traveller traveller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != traveller.travellerID)
            {
                return BadRequest();
            }

            _context.Entry(traveller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravellerExists(id))
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

        // POST: api/Travellers
        [HttpPost]
        public async Task<IActionResult> PostTraveller([FromBody] Traveller traveller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.traveller.Add(traveller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraveller", new { id = traveller.travellerID }, traveller);
        }

        // DELETE: api/Travellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraveller([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var traveller = await _context.traveller.FindAsync(id);
            if (traveller == null)
            {
                return NotFound();
            }

            _context.traveller.Remove(traveller);
            await _context.SaveChangesAsync();

            return Ok(traveller);
        }

        private bool TravellerExists(int id)
        {
            return _context.traveller.Any(e => e.travellerID == id);
        }
    }
}
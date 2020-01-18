using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private readonly HotelContext _context;

        public StandardController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Standard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standard>>> GetStandard()
        {
            return await _context.Standard.ToListAsync();
        }

        // GET: api/Standard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Standard>> GetStandard(int id)
        {
            var standard = await _context.Standard.FindAsync(id);

            if (standard == null)
            {
                return NotFound();
            }

            return standard;
        }

        // PUT: api/Standard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStandard(int id, Standard standard)
        {
            if (id != standard.StandardPokoju)
            {
                return BadRequest();
            }

            _context.Entry(standard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardExists(id))
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

        // POST: api/Standard
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Standard>> PostStandard(Standard standard)
        {
            _context.Standard.Add(standard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStandard), new { id = standard.StandardPokoju }, standard);
        }

        // DELETE: api/Standard/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Standard>> DeleteStandard(int id)
        {
            var standard = await _context.Standard.FindAsync(id);
            if (standard == null)
            {
                return NotFound();
            }

            _context.Standard.Remove(standard);
            await _context.SaveChangesAsync();

            return standard;
        }

        private bool StandardExists(int id)
        {
            return _context.Standard.Any(e => e.StandardPokoju == id);
        }
    }
}

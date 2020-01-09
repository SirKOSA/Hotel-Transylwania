using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokojController : ControllerBase
    {
        private readonly PokojContext _context;

        public PokojController(PokojContext context)
        {
            _context = context;
        }

        // GET: api/Pokoj
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokoj>>> GetPokoj()
        {
            return await _context.Pokoj.ToListAsync();
        }

        // GET: api/Pokoj/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokoj>> GetPokoj(int id)
        {
            var pokoj = await _context.Pokoj.FindAsync(id);

            if (pokoj == null)
            {
                return NotFound();
            }

            return pokoj;
        }

        // PUT: api/Pokoj/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokoj(int id, Pokoj pokoj)
        {
            if (id != pokoj.Nr_Pokoju)
            {
                return BadRequest();
            }

            _context.Entry(pokoj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokojExists(id))
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

        // POST: api/Pokoj
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pokoj>> PostPokoj(Pokoj pokoj)
        {
            _context.Pokoj.Add(pokoj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokoj), new { id = pokoj.Nr_Pokoju }, pokoj);
        }

        // DELETE: api/Pokoj/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pokoj>> DeletePokoj(int id)
        {
            var pokoj = await _context.Pokoj.FindAsync(id);
            if (pokoj == null)
            {
                return NotFound();
            }

            _context.Pokoj.Remove(pokoj);
            await _context.SaveChangesAsync();

            return pokoj;
        }

        private bool PokojExists(int id)
        {
            return _context.Pokoj.Any(e => e.Nr_Pokoju == id);
        }
    }
}

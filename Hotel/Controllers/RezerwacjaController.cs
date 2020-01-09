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
    public class RezerwacjaController : ControllerBase
    {
        private readonly HotelContext _context;

        public RezerwacjaController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Rezerwacja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rezerwacja>>> GetRezerwacja()
        {
            return await _context.Rezerwacja.ToListAsync();
        }

        // GET: api/Rezerwacja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rezerwacja>> GetRezerwacja(int id)
        {
            var rezerwacja = await _context.Rezerwacja.FindAsync(id);

            if (rezerwacja == null)
            {
                return NotFound();
            }

            return rezerwacja;
        }

        // PUT: api/Rezerwacja/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezerwacja(int id, Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.Id_Rezerwacji)
            {
                return BadRequest();
            }

            _context.Entry(rezerwacja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezerwacjaExists(id))
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

        // POST: api/Rezerwacja
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Rezerwacja>> PostRezerwacja(Rezerwacja rezerwacja)
        {
            Klient k = new Klient() {Imie = rezerwacja._Klient.Imie, Nazwisko = rezerwacja._Klient.Nazwisko };
            Pokoj p = new Pokoj() { Wolny = rezerwacja._Pokoj.Wolny };
            _context.Klient.Add(k);
            _context.Pokoj.Add(p);
            rezerwacja._Klient = k;
            rezerwacja._Pokoj = p;
            _context.Rezerwacja.Add(rezerwacja);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRezerwacja), new { id = rezerwacja.Id_Rezerwacji }, rezerwacja);
        }

        // DELETE: api/Rezerwacja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rezerwacja>> DeleteRezerwacja(int id)
        {
            var rezerwacja = await _context.Rezerwacja.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            _context.Rezerwacja.Remove(rezerwacja);
            await _context.SaveChangesAsync();

            return rezerwacja;
        }

        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacja.Any(e => e.Id_Rezerwacji == id);
        }
    }
}

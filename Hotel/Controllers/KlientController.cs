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
    // KlientController - kontroler odpowiadający za obsługę encji w tabeli Klient
    [Route("api/[controller]")]
    [ApiController]
    public class KlientController : ControllerBase
    {
        private readonly HotelContext _context;

        public KlientController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Klient
        // Ta funkcja zwraca listę wszystkich encji zapisanych w tabeli Klient.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klient>>> GetKlient()
        {
            return await _context.Klient.ToListAsync();
        }

        // GET: api/Klient/5
        // Ta funkcja zwraca jedną encję o określonym identyfikatorze (id) z tabeli Klient.
        [HttpGet("{id}")]
        public async Task<ActionResult<Klient>> GetKlient(int id)
        {
            var klient = await _context.Klient.FindAsync(id);

            if (klient == null)
            {
                return NotFound();
            }

            return klient;
        }

        // PUT: api/Klient/5
        // Ta funkcja wprowadza zmiany w danych encji o określonym identyfikatorze (id) w tabeli Klient.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlient(int id, Klient klient)
        {
            /*
            if (id != klient.Id_Klient)
            {
                return BadRequest();
            }
            */

            klient.Id_Klient = id;
            _context.Entry(klient).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!KlientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(e.Message + "\n" + e.StackTrace);
                }
            }

            return NoContent();
        }

        // POST: api/Klient
        // Ta funkcja dodaje do bazy danych nową encję (klienta).
        // Jej nowy identyfikator jest przypisywany automatycznie jako inkrementacja ID ostatniej zapisanej encji.
        [HttpPost]
        public async Task<ActionResult<Klient>> PostKlient(Klient klient)
        {
            _context.Klient.Add(klient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKlient), new { id = klient.Id_Klient }, klient);
        }

        // DELETE: api/Klient/5
        // Ta funkcja usuwa z tabeli Klient encję o określonym identyfikatorze (id).
        [HttpDelete("{id}")]
        public async Task<ActionResult<Klient>> DeleteKlient(int id)
        {
            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }

            _context.Klient.Remove(klient);
            await _context.SaveChangesAsync();

            return klient;
        }

        // Funkcja pomocnicza sprawdzająca, czy encja o określonym identyfikatorze (id) istnieje w tabeli.
        private bool KlientExists(int id)
        {
            return _context.Klient.Any(e => e.Id_Klient == id);
        }
    }
}

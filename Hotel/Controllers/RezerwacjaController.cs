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
    // RezerwacjaController - kontroler odpowiadający za obsługę encji w tabeli Pokoj
    [Route("api/[controller]")]
    [ApiController]
    public class RezerwacjaController : ControllerBase
    {
        private readonly HotelContext _context;

        public RezerwacjaController(HotelContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  GET: api/Rezerwacja
        /// </summary>
        /// <remarks>
        /// Ta funkcja zwraca listę wszystkich encji zapisanych w tabeli Rezerwacja.
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rezerwacja>>> GetRezerwacja()
        {
            return await _context.Rezerwacja.ToListAsync();
        }

        /// <summary>
        ///  GET: api/Rezerwacja/5
        /// </summary>
        /// <remarks>
        /// Ta funkcja zwraca jedną encję o określonym identyfikatorze (id) z tabeli Rezerwacja.
        /// </remarks>
        /// <param name="id">podaj numer id rezerwacji którą chciałbyś wyjąć z bazy danych</param>
        /// <returns></returns>
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

        /// <summary>
        ///  PUT: api/Rezerwacja/5
        /// </summary>
        /// <remarks>
        /// Ta funkcja wprowadza zmiany w danych encji o określonym identyfikatorze (id) w tabeli Rezerwacja.
        /// </remarks>
        /// <param name="id">podaj numer id rezerwacji którą chcesz zaktualizować w bazie</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezerwacja(int id, Rezerwacja rezerwacja)
        {
            /*
            if (id != rezerwacja.Id_Rezerwacji)
            {
                return BadRequest();
            }
            */

            rezerwacja.Id_Rezerwacji = id;
            _context.Entry(rezerwacja).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!RezerwacjaExists(id))
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

        /// <summary>
        ///  POST: api/Rezerwacja
        /// </summary>
        /// <remarks>
        /// Ta funkcja dodaje do bazy danych nową encję (rezerwację).
        /// Jej nowy identyfikator jest przypisywany automatycznie jako inkrementacja ID ostatniej zapisanej encji.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Rezerwacja>> PostRezerwacja(Rezerwacja rezerwacja)
        {
            try
            {
                _context.Klient.Find(rezerwacja.id_klient);
                _context.Standard.Find(_context.Pokoj.Find(rezerwacja.nr_pokoju).Standard_pokoju);
                Pokoj p = _context.Pokoj.Find(rezerwacja.nr_pokoju);
                Standard s = _context.Standard.Find(_context.Pokoj.Find(rezerwacja.nr_pokoju).Standard_pokoju);
                rezerwacja.Cena = 0.00f;
                rezerwacja.Cena = s.CenaStandardu * (rezerwacja.Data_Zakonczenia_Rezerwacji - rezerwacja.Data_Rozpoczecia_Rezerwacji).Days - (p.Liczba_miejsc * 10)+10; 
                _context.Rezerwacja.Add(rezerwacja);
                await _context.SaveChangesAsync();
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e.Message + "\n" + e.StackTrace);
            }

            return CreatedAtAction(nameof(GetRezerwacja), new { id = rezerwacja.Id_Rezerwacji }, rezerwacja);
        }

        /// <summary>
        ///  DELETE: api/Rezerwacja/5
        /// </summary>
        /// <remarks>
        /// Ta funkcja usuwa z tabeli Rezerwacja encję o określonym identyfikatorze (id).
        /// </remarks>
        /// <param name="id">podaj numer id rezerwacji którą chciałbyś z bazy usunąć</param>
        /// <returns></returns>
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

        // Funkcja pomocnicza sprawdzająca, czy encja o określonym identyfikatorze (id) istnieje w tabeli.
        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacja.Any(e => e.Id_Rezerwacji == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel;
using Hotel.Models;
using Swashbuckle.AspNetCore.Filters;

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

        /// <summary>
        /// GET: api/Klient
        /// </summary>
        /// <remarks>
        /// Ta funkcja zwraca listę wszystkich encji zapisanych w tabeli Klient.
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klient>>> GetKlient()
        {
            return await _context.Klient.ToListAsync();
        }

        /// <summary>
        /// GET: api/Klient/5
        /// </summary>
        /// <remarks>
        /// Ta funkcja zwraca jedną encję o określonym identyfikatorze (id) z tabeli Klient.
        /// </remarks>
        /// <param name="id">tu podaj identyfikator klienta którego chcesz otrzymać</param>
        /// <returns></returns>
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

        /// <summary>
        /// / PUT: api/Klient/5
        /// </summary>
        /// <remarks>
        /// Ta funkcja wprowadza zmiany w danych encji o określonym identyfikatorze (id) w tabeli Klient.
        /// </remarks>
        /// <param name="id">zaktualizuj dane klienta o tym identyfikatorze</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlient(int id, Klient klient)
        {

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

        /// <summary>
        ///  POST: api/Klient
        /// </summary>
        /// <remarks>
        /// Ta funkcja dodaje do bazy danych nową encję (klienta).
        /// Jej nowy identyfikator jest przypisywany automatycznie jako inkrementacja ID ostatniej zapisanej encji.
        /// </remarks>
        /// <param name="KlientCreateSettings">Tworzy nowego klienta</param>
        /// <returns></returns>
        [SwaggerResponseExample(201, typeof(Klient.Example))]
        [SwaggerRequestExample(typeof(Klient.Create), typeof(Klient.Create.Example))]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<Klient>> PostKlient(Klient.Create
            KlientCreateSettings)
        {
            Klient newKlient = new Klient();
            newKlient.Imie = KlientCreateSettings.Imie;
            newKlient.Nazwisko = KlientCreateSettings.Nazwisko;

            _context.Klient.Add(newKlient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKlient), new { id = newKlient.Id_Klient }, newKlient);
        }

        /// <summary>
        ///  DELETE: api/Klient/
        /// </summary>
        /// <remarks>
        /// Ta funkcja usuwa z tabeli Klient encję o określonym identyfikatorze (id).
        /// </remarks>
        /// <param name="id">usuń klienta o danym identyfikatorze</param>
        /// <returns></returns>
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

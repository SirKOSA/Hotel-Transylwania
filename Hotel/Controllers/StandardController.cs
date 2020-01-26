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

        /// <summary>
        ///  GET: api/Standard
        /// </summary>
        /// <remarks>
        /// Funkcja zwraca wszystkie dane z tabeli Standard
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standard>>> GetStandard()
        {
            return await _context.Standard.ToListAsync();
        }

        /// <summary>
        /// GET: api/Standard/5
        /// </summary>
        /// <remarks>
        /// Funkcja zwraca konkretną encje o podanym identyfikatorze
        /// </remarks>
        /// <param name="id">tu podaj identyfikator standardu który chcesz wyciągnąć z bazy</param>
        /// <returns></returns>
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

        /// <summary>
        ///  PUT: api/Standard/5
        /// </summary>
        /// <remarks>
        /// funkcja aktualizuje istniejący rekord o danym id w tabeli Standart
        /// </remarks>
        /// <param name="id">tu podaj id rekordu do aktualizacji</param>
        /// <returns></returns>
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

        /// <summary>
        /// POST: api/Standard
        /// </summary>
        /// <remarks>
        /// Funkcja tworzy/aktualizuje pozycje w encji Standart
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Standard>> PostStandard(Standard standard)
        {
            _context.Standard.Add(standard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStandard), new { id = standard.StandardPokoju }, standard);
        }

        /// <summary>
        ///  DELETE: api/Standard/5
        /// </summary>
        /// <remarks>
        /// Funkcja usuwa pozycje o danym id z tabeli Standard
        /// </remarks>
        /// <param name="id">Tu podaj Id standardu który chcesz usunąć</param>
        /// <returns></returns>
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

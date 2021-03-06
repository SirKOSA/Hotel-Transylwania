﻿using System;
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
    // PokojController - kontroler odpowiadający za obsługę encji w tabeli Pokoj
    [Route("api/[controller]")]
    [ApiController]
    public class PokojController : ControllerBase
    {
        private readonly HotelContext _context;

        public PokojController(HotelContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  GET: api/Pokoj
        /// </summary>
        /// <remarks>
        /// Ta funkcja zwraca listę wszystkich encji zapisanych w tabeli Pokoj.
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokoj>>> GetPokoj()
        {
            return await _context.Pokoj.ToListAsync();
        }

        /// <summary>
        ///  GET: api/Pokoj/5
        /// </summary>
        /// <remarks>
        /// Ta funkcja zwraca jedną encję o określonym identyfikatorze (id) z tabeli Pokoj.
        /// </remarks>
        /// <param name="id">tutaj wpisz identyfikator pokoju który chcesz pobrać z bazy</param>
        /// <returns></returns>
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

        /// <summary>
        ///  PUT: api/Pokoj/5 
        /// </summary>
        /// <remarks>
        /// Ta funkcja wprowadza zmiany w danych encji o określonym identyfikatorze (id) w tabeli Pokoj.
        /// </remarks>
        /// <param name="id">tutaj wpisz numer id pokoju który chcesz zaktualizować</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokoj(int id, Pokoj pokoj)
        {
            /*
            if (id != pokoj.Nr_Pokoju)
            {
                return BadRequest();
            }
            */

            pokoj.Nr_Pokoju = id;
            _context.Entry(pokoj).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!PokojExists(id))
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
        ///  POST: api/Pokoj
        /// </summary>
        /// <remarks>
        /// Ta funkcja dodaje do bazy danych nową encję (pokój).
        /// Jej nowy identyfikator jest przypisywany automatycznie jako inkrementacja ID ostatniej zapisanej encji.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Pokoj>> PostPokoj(Pokoj pokoj)
        {
            _context.Pokoj.Add(pokoj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokoj), new { id = pokoj.Nr_Pokoju }, pokoj);
        }

        /// <summary>
        /// DELETE: api/Pokoj/5
        /// </summary>
        /// <remarks>
        ///  Ta funkcja usuwa z tabeli Pokoj encję o określonym identyfikatorze (id).
        /// </remarks>
        /// <param name="id">podaj id pokoju który chciałbyś usunąć</param>
        /// <returns></returns>
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

        // Funkcja pomocnicza sprawdzająca, czy encja o określonym identyfikatorze (id) istnieje w tabeli.
        private bool PokojExists(int id)
        {
            return _context.Pokoj.Any(e => e.Nr_Pokoju == id);
        }
    }
}

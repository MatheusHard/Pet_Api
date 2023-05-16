using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Api.Database;
using Pet_Api.Models;

namespace Pet_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetsController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoPetsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TipoPets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPet>>> GetTiposPets()
        {
          if (_context.TiposPets == null)
          {
              return NotFound();
          }
            return await _context.TiposPets.ToListAsync();
        }

        // GET: api/TipoPets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPet>> GetTipoPet(int id)
        {
          if (_context.TiposPets == null)
          {
              return NotFound();
          }
            var tipoPet = await _context.TiposPets.FindAsync(id);

            if (tipoPet == null)
            {
                return NotFound();
            }

            return tipoPet;
        }

        // PUT: api/TipoPets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPet(int id, TipoPet tipoPet)
        {
            if (id != tipoPet.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPetExists(id))
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

        // POST: api/TipoPets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPet>> PostTipoPet(TipoPet tipoPet)
        {
          if (_context.TiposPets == null)
          {
              return Problem("Entity set 'DataContext.TiposPets'  is null.");
          }
            _context.TiposPets.Add(tipoPet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPet", new { id = tipoPet.Id }, tipoPet);
        }

        // DELETE: api/TipoPets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPet(int id)
        {
            if (_context.TiposPets == null)
            {
                return NotFound();
            }
            var tipoPet = await _context.TiposPets.FindAsync(id);
            if (tipoPet == null)
            {
                return NotFound();
            }

            _context.TiposPets.Remove(tipoPet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPetExists(int id)
        {
            return (_context.TiposPets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

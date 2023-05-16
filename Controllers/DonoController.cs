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
    public class DonoController : ControllerBase
    {
        private readonly DataContext _context;

        public DonoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Dono
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dono>>> GetDonos()
        {
          if (_context.Donos == null)
          {
              return NotFound();
          }
            return await _context.Donos.ToListAsync();
        }

        // GET: api/Dono/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dono>> GetDono(int id)
        {
          if (_context.Donos == null)
          {
              return NotFound();
          }
            var dono = await _context.Donos.FindAsync(id);

            if (dono == null)
            {
                return NotFound();
            }

            return dono;
        }

        // PUT: api/Dono/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDono(int id, Dono dono)
        {
            if (id != dono.Id)
            {
                return BadRequest();
            }

            _context.Entry(dono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonoExists(id))
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

        // POST: api/Dono
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dono>> PostDono(Dono dono)
        {
          if (_context.Donos == null)
          {
              return Problem("Entity set 'DataContext.Donos'  is null.");
          }
            _context.Donos.Add(dono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDono", new { id = dono.Id }, dono);
        }

        // DELETE: api/Dono/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDono(int id)
        {
            if (_context.Donos == null)
            {
                return NotFound();
            }
            var dono = await _context.Donos.FindAsync(id);
            if (dono == null)
            {
                return NotFound();
            }

            _context.Donos.Remove(dono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonoExists(int id)
        {
            return (_context.Donos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

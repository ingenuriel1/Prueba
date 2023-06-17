using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecaudosAPI.Context;
using RecaudosAPI.Models;

namespace RecaudosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecaudosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecaudosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Recaudos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recaudos>>> GetRecaudo()
        {
          if (_context.Recaudo == null)
          {
              return NotFound();
          }
            return await _context.Recaudo.ToListAsync();
        }

        // GET: api/Recaudos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recaudos>> GetRecaudos(int id)
        {
          if (_context.Recaudo == null)
          {
              return NotFound();
          }
            var recaudos = await _context.Recaudo.FindAsync(id);

            if (recaudos == null)
            {
                return NotFound();
            }

            return recaudos;
        }

        // PUT: api/Recaudos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecaudos(int id, Recaudos recaudos)
        {
            if (id != recaudos.Id)
            {
                return BadRequest();
            }

            _context.Entry(recaudos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecaudosExists(id))
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

        // POST: api/Recaudos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recaudos>> PostRecaudos(Recaudos recaudos)
        {
          if (_context.Recaudo == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Recaudo'  is null.");
          }
            _context.Recaudo.Add(recaudos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecaudos", new { id = recaudos.Id }, recaudos);
        }

        // DELETE: api/Recaudos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecaudos(int id)
        {
            if (_context.Recaudo == null)
            {
                return NotFound();
            }
            var recaudos = await _context.Recaudo.FindAsync(id);
            if (recaudos == null)
            {
                return NotFound();
            }

            _context.Recaudo.Remove(recaudos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecaudosExists(int id)
        {
            return (_context.Recaudo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

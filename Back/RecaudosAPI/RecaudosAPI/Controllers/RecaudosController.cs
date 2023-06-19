using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        [HttpGet]
        [Route("GetTotales")]
        public async Task<ActionResult<IEnumerable<Totales>>> GetReporte()
        {
            if (_context.Recaudo == null)
            {
                return NotFound();
            }
            List<Totales> listTotales = new List<Totales>();
            Totales totales = new Totales();

            var datos = await _context.Recaudo.ToListAsync();
            int totalCan = 0;
            int totalVal = 0;
            try
            {
                foreach (var item in datos)
                {
                    totalCan = totalCan + item.cantidad;
                    totalVal = totalVal + item.valorTabulado;
                    Console.Write(item);
                }
                totales.totalCantidad = totalCan.ToString();
                totales.totalValor = totalVal.ToString();
                listTotales.Add(totales);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return listTotales;
        }
        [HttpGet]
        [Route("Fechas")]
        public async Task<ActionResult<IEnumerable<Fechas>>> Fechas()
        {
            if (_context.Recaudo == null)
            {
                return NotFound();
            }
            var datos = await _context.Recaudo.ToListAsync();
            List<Fechas> ListFechas = new List<Fechas>();
            Fechas fechas = new Fechas();
            try
            {
                var result = (from item in datos
                              group item by item.fecha into g
                              select new Fechas()
                              {
                                  fecha = g.Key,
                                  totalCantidad = g.Sum(x => x.cantidad).ToString(),
                                  totalValor = g.Sum(x => x.valorTabulado).ToString()
                              });
                foreach (var item in result)
                {

                    ListFechas.Add(
                    new Fechas()
                    {
                       fecha=item.fecha,
                       totalCantidad=item.totalCantidad,
                       totalValor=item.totalValor
                    }
                        );

                }

            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return ListFechas;
        }
        [HttpGet]
        [Route("Estaciones")]
        public async Task<ActionResult<IEnumerable<Estaciones>>> Estaciones()
        {
            if (_context.Recaudo == null)
            {
                return NotFound();
            }
            var datos = await _context.Recaudo.ToListAsync();
            List<Estaciones> ListEstaciones = new List<Estaciones>();
            try
            {

                var result = (from item in datos
                              group item by item.estacion into g
                              select new Estaciones()
                              {
                                  estacion = g.Key,
                                  fechas=new DateTime(),
                                  totalCantidadF = g.Sum(x => x.cantidad),
                                  totalValorF = g.Sum(x => x.valorTabulado)
                              });

                foreach (var item in result)
                {

                    ListEstaciones.Add(
                    new Estaciones()
                    {
                        estacion = item.estacion,
                        totalCantidadF = item.totalCantidadF,
                        totalValorF = item.totalValorF,
                        fechas = item.fechas
                    }
                        );

                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return ListEstaciones;
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

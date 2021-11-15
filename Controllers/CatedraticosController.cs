using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using devwebfinal.Data;
using devwebfinal.Models;

namespace devwebfinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatedraticosController : ControllerBase
    {
        private readonly devwebfinalContext _context;

        public CatedraticosController(devwebfinalContext context)
        {
            _context = context;
        }

        // GET: api/Catedraticos
        //devuelve todos los catedraticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catedraticos>>> GetCatedraticos()
        {
            return await _context.Catedraticos.ToListAsync();
        }

        // GET: api/Catedraticos/5 
        //busqueda por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Catedraticos>> GetCatedraticos(int id)
        {
            var catedraticos = await _context.Catedraticos.FindAsync(id);

            if (catedraticos == null)
            {
                return NotFound();
            }

            return catedraticos;
        }
        // GET: api/Catedraticos/getActivos
        //devuelve todos los catedraticos activos
        [HttpGet]
        [Route("getActivos")]
        public async Task<ActionResult<IEnumerable<Catedraticos>>> GetCatedraticosActivos()
        {
            var catedraticos =  _context.Catedraticos.Where(element => element.estado == "activo");

            if (catedraticos == null)
            {
                return NotFound();
            }

            return await catedraticos.ToListAsync();
        }
        // GET: api/Catedraticos/getAprobados
        //devuelve todos los catedraticos Aprobados
        [HttpGet]
        [Route("getAprobados")]
        public async Task<ActionResult<IEnumerable<Catedraticos>>> GetCatedraticosAprobados()
        {
            var catedraticos = _context.Catedraticos.Where(element => element.aprobado == "si");

            if (catedraticos == null)
            {
                return NotFound();
            }

            return await catedraticos.ToListAsync();
        }
        // GET: api/Catedraticos/getReprobados
        //devuelve todos los catedraticos reprobados
        [HttpGet]
        [Route("getReprobados")]
        public async Task<ActionResult<IEnumerable<Catedraticos>>> GetCatedraticosReprobados()
        {
            var catedraticos = _context.Catedraticos.Where(element => element.aprobado == "no");

            if (catedraticos == null)
            {
                return NotFound();
            }

            return await catedraticos.ToListAsync();
        }


        // PUT: api/Catedraticos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatedraticos(int id, Catedraticos catedraticos)
        {
            if (id != catedraticos.idcatedratico)
            {
                return BadRequest();
            }

            _context.Entry(catedraticos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatedraticosExists(id))
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

        // POST: api/Catedraticos
        [HttpPost]
        public async Task<ActionResult<Catedraticos>> PostCatedraticos(Catedraticos catedraticos)
        {
            _context.Catedraticos.Add(catedraticos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatedraticos", new { id = catedraticos.idcatedratico }, catedraticos);
        }

        // DELETE: api/Catedraticos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Catedraticos>> DeleteCatedraticos(int id)
        {
            var catedraticos = await _context.Catedraticos.FindAsync(id);
            if (catedraticos == null)
            {
                return NotFound();
            }

            _context.Catedraticos.Remove(catedraticos);
            await _context.SaveChangesAsync();

            return catedraticos;
        }

        private bool CatedraticosExists(int id)
        {
            return _context.Catedraticos.Any(e => e.idcatedratico == id);
        }
    }
}

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
    public class CursosController : ControllerBase
    {
        private readonly devwebfinalContext _context;

        public CursosController(devwebfinalContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cursos>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cursos>> GetCursos(int id)
        {
            var cursos = await _context.Cursos.FindAsync(id);

            if (cursos == null)
            {
                return NotFound();
            }

            return cursos;
        }

        // PUT: api/Cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursos(int id, Cursos cursos)
        {
            if (id != cursos.Idcurso)
            {
                return BadRequest();
            }

            _context.Entry(cursos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursosExists(id))
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

        // POST: api/Cursos
        [HttpPost]
        public async Task<ActionResult<Cursos>> PostCursos(Cursos cursos)
        {
            _context.Cursos.Add(cursos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursos", new { id = cursos.Idcurso }, cursos);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cursos>> DeleteCursos(int id)
        {
            var cursos = await _context.Cursos.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }

            _context.Cursos.Remove(cursos);
            await _context.SaveChangesAsync();

            return cursos;
        }

        private bool CursosExists(int id)
        {
            return _context.Cursos.Any(e => e.Idcurso == id);
        }
    }
}

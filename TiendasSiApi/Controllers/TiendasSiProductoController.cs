using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendasSiApi.Entities;
using TiendasSiApi.DbTiendasSi;

namespace TiendasSiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasSiProductoController : ControllerBase
    {
        private readonly TiendasSiDbContext _context;

        public TiendasSiProductoController(TiendasSiDbContext context)
        {
            _context = context;
        }

        // GET: api/TiendasSiProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendasSiProducto>>> GetTiendasSiProducto()
        {
            return await _context.TiendasSiProducto.ToListAsync();
        }

        // GET: api/TiendasSiProducto/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TiendasSiProducto>> GetTiendasSiProducto(int id)
        {
            var tiendasSiProducto = await _context.TiendasSiProducto.FindAsync(id);

            if (tiendasSiProducto == null)
            {
                return NotFound();
            }

            return tiendasSiProducto;
        }

        // GET: api/TiendasSiProducto/GetTiendasSiProductoByTipo/idTipoProducto
        [Route("GetTiendasSiProductoByTipo/{idTipoProducto}"), HttpGet]
        public async Task<ActionResult<IEnumerable<TiendasSiProducto>>> GetTiendasSiProductoByTipo(int idTipoProducto)
        {
            var tiendasSiProducto = await _context.TiendasSiProducto.Where(x => x.idTipoProducto == idTipoProducto).ToListAsync();

            if (tiendasSiProducto == null)
            {
                return NotFound();
            }

            return tiendasSiProducto;
        }

        // PUT: api/TiendasSiProducto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiendasSiProducto(int id, TiendasSiProducto TiendasSiProducto)
        {
            if (id != TiendasSiProducto.id)
            {
                return BadRequest();
            }

            _context.Entry(TiendasSiProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendasSiProductoExists(id))
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

        // POST: api/TiendasSiProducto
        [HttpPost]
        public async Task<ActionResult<TiendasSiProducto>> PostTiendasSiProducto(TiendasSiProducto TiendasSiProducto)
        {
            _context.TiendasSiProducto.Add(TiendasSiProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiendasSiProducto", new { id = TiendasSiProducto.id }, TiendasSiProducto);
        }

        // DELETE: api/TiendasSiProducto/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiendasSiProducto(int id)
        {
            var tiendasSiProducto = await _context.TiendasSiProducto.FindAsync(id);
            if (tiendasSiProducto == null)
            {
                return NotFound();
            }

            _context.TiendasSiProducto.Remove(tiendasSiProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiendasSiProductoExists(int id)
        {
            return _context.TiendasSiProducto.Any(e => e.id == id);
        }
    }
}

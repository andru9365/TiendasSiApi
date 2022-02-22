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
    public class TiendasSiTipoProductoController : ControllerBase
    {
        private readonly TiendasSiDbContext _context;

        public TiendasSiTipoProductoController(TiendasSiDbContext context)
        {
            _context = context;
        }

        // GET: api/TiendasSiTipoProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendasSiTipoProducto>>> GetTiendasSiTipoProducto()
        {
            return await _context.TiendasSiTipoProducto.ToListAsync();
        }

        // GET: api/TiendasSiTipoProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiendasSiTipoProducto>> GetTiendasSiTipoProducto(int id)
        {
            var tiendasSiTipoProducto = await _context.TiendasSiTipoProducto.FindAsync(id);

            if (tiendasSiTipoProducto == null)
            {
                return NotFound();
            }

            return tiendasSiTipoProducto;
        }

        // PUT: api/TiendasSiTipoProducto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetTiendasSiTipoProducto(int id, TiendasSiTipoProducto tiendasSiTipoProducto)
        {
            if (id != tiendasSiTipoProducto.id)
            {
                return BadRequest();
            }

            _context.Entry(tiendasSiTipoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendasSiTipoProductoExists(id))
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

        // POST: api/TiendasSiTipoProducto
        [HttpPost]
        public async Task<ActionResult<TiendasSiTipoProducto>> PostTiendasSiTipoProducto(TiendasSiTipoProducto tiendasSiTipoProducto)
        {
            _context.TiendasSiTipoProducto.Add(tiendasSiTipoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiendasSiTipoProducto", new { id = tiendasSiTipoProducto.id }, tiendasSiTipoProducto);
        }

        // DELETE: api/TiendasSiTipoProducto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiendasSiTipoProducto(int id)
        {
            var tiendasSiTipoProducto = await _context.TiendasSiTipoProducto.FindAsync(id);
            if (tiendasSiTipoProducto == null)
            {
                return NotFound();
            }

            _context.TiendasSiTipoProducto.Remove(tiendasSiTipoProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiendasSiTipoProductoExists(int id)
        {
            return _context.TiendasSiTipoProducto.Any(e => e.id == id);
        }
    }
}

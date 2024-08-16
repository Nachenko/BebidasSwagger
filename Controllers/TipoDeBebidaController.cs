namespace BebidasSwagger.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class TipoDeBebidaController : ControllerBase
    {
        private readonly BebidasContext _context;

        public TipoDeBebidaController(BebidasContext context)
        {
            _context = context;
        }

        // GET: api/TipoDeBebida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeBebida>>> GetTiposDeBebida()
        {
            return await _context.TiposDeBebida.ToListAsync();
        }

        // GET: api/TipoDeBebida/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeBebida>> GetTipoDeBebida(int id)
        {
            var tipoDeBebida = await _context.TiposDeBebida.FindAsync(id);
            if (tipoDeBebida == null)
            {
                return NotFound();
            }
            return tipoDeBebida;
        }

        // POST: api/TipoDeBebida
        [HttpPost]
        public async Task<ActionResult<TipoDeBebida>> PostTipoDeBebida(TipoDeBebida tipoDeBebida)
        {
            _context.TiposDeBebida.Add(tipoDeBebida);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoDeBebida), new { id = tipoDeBebida.IdTipoDeBebida }, tipoDeBebida);
        }

        // PUT: api/TipoDeBebida/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeBebida(int id, TipoDeBebida tipoDeBebida)
        {
            if (id != tipoDeBebida.IdTipoDeBebida)
            {
                return BadRequest();
            }

            _context.Entry(tipoDeBebida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TiposDeBebida.Any(e => e.IdTipoDeBebida == id))
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

        // DELETE: api/TipoDeBebida/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeBebida(int id)
        {
            var tipoDeBebida = await _context.TiposDeBebida.FindAsync(id);
            if (tipoDeBebida == null)
            {
                return NotFound();
            }

            _context.TiposDeBebida.Remove(tipoDeBebida);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

namespace BebidasSwagger.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        private readonly BebidasContext _context;

        public BebidasController(BebidasContext context)
        {
            _context = context;
        }

        // GET: api/bebidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
        {
            return await _context.Bebidas.Include(b => b.TipoDeBebida).ToListAsync();
        }

        // GET: api/bebidas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Bebida>> GetBebida(int id)
        {
            var bebida = await _context.Bebidas.Include(b => b.TipoDeBebida)
                                               .FirstOrDefaultAsync(b => b.Id_bebida == id);
            if (bebida == null)
            {
                return NotFound();
            }
            return bebida;
        }

        // POST: api/bebidas
        [HttpPost]
        public async Task<ActionResult<Bebida>> PostBebida(Bebida bebida)
        {
            // Validar que el TipoDeBebida existe
            var tipoDeBebida = await _context.TiposDeBebida.FindAsync(bebida.IdTipoDeBebida);
            if (tipoDeBebida == null)
            {
                return BadRequest("El tipo de bebida no existe.");
            }

            // Asignar el TipoDeBebida existente a la Bebida
            bebida.TipoDeBebida = tipoDeBebida;

            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBebida), new { id = bebida.Id_bebida }, bebida);
        }

        // PUT: api/bebidas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBebida(int id, Bebida bebida)
        {
            if (id != bebida.Id_bebida)
            {
                return BadRequest();
            }

            // Validar que el TipoDeBebida existe
            var tipoDeBebida = await _context.TiposDeBebida.FindAsync(bebida.IdTipoDeBebida);
            if (tipoDeBebida == null)
            {
                return BadRequest("El tipo de bebida no existe.");
            }

            // Asignar el TipoDeBebida existente a la Bebida
            bebida.TipoDeBebida = tipoDeBebida;

            _context.Entry(bebida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bebidas.Any(e => e.Id_bebida == id))
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

        // DELETE: api/bebidas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBebida(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }

            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

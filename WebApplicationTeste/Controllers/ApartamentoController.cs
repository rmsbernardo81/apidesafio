using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTeste.Data;
using WebApplicationTeste.Model;

namespace WebApplicationTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentoController : ControllerBase
    {
        private readonly WebApiTesteDesafioContext _context;

        public ApartamentoController(WebApiTesteDesafioContext context)
        {
            _context = context;
        }

        // GET: api/Apartamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartamento>>> GetApartamento()
        {
            return await _context.Apartamento.Include(r => r.Moradores).ToListAsync();
        }

        // GET: api/Apartamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartamento>> GetApartamento(int id)
        {
            var apartamento = await _context.Apartamento
                .Include(r => r.Moradores)
                .FirstOrDefaultAsync(i => i.ApartamentoId == id);

            if (apartamento == null)
            {
                return NotFound();
            }

            return apartamento;
        }

        // PUT: api/Apartamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartamento(int id, int blocoid, string numero, string andar)
        {
            var apartamento = new Apartamento { Numero = numero, Andar = andar, BlocoId = blocoid };

            if (id < 0)
            {
                return BadRequest();
            }

            _context.Entry(apartamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentoExists(id))
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

        // POST: api/Apartamento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartamento>> PostApartamento(int blocoid, string numero, string andar)
        {
            var apartamento = new Apartamento { Numero = numero, Andar = andar, BlocoId = blocoid };
            _context.Apartamento.Add(apartamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartamento", new { id = apartamento.ApartamentoId }, 
                new { ApartamentoId = apartamento.ApartamentoId, Numero = apartamento.Numero, Andar = apartamento.Andar });
        }

        // DELETE: api/Apartamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartamento(int id)
        {
            var apartamento = await _context.Apartamento.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }

            _context.Apartamento.Remove(apartamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartamentoExists(int id)
        {
            return _context.Apartamento.Any(e => e.ApartamentoId == id);
        }
    }
}

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
    public class BlocoController : ControllerBase
    {
        private readonly WebApiTesteDesafioContext _context;

        public BlocoController(WebApiTesteDesafioContext context)
        {
            _context = context;
        }

        // GET: api/Bloco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bloco>>> GetBloco()
        {
            return await _context.Bloco
                .Include(r => r.Apartamentos)
                .ThenInclude(r => r.Moradores)
                .ToListAsync();
        }

        // GET: api/Bloco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bloco>> GetBloco(int id)
        {
            var bloco = await _context.Bloco
                .Include(r => r.Apartamentos)
                .ThenInclude(r => r.Moradores)
                .FirstOrDefaultAsync(i => i.BlocoId == id);

            if (bloco == null)
            {
                return NotFound();
            }

            return bloco;
        }

        // PUT: api/Bloco/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloco(int id, int condominioId, string nome)
        {
            var bloco = new Bloco { CondominioId = condominioId, Nome = nome };

            if (id < 0)
            {
                return BadRequest();
            }

            _context.Entry(bloco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlocoExists(id))
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

        // POST: api/Bloco
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bloco>> PostBloco(int condominioId, string nome)
        {
            var bloco = new Bloco { CondominioId = condominioId, Nome = nome };
            _context.Bloco.Add(bloco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloco", new { id = bloco.BlocoId }, bloco);
        }

        // DELETE: api/Bloco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloco(int id)
        {
            var bloco = await _context.Bloco.FindAsync(id);
            if (bloco == null)
            {
                return NotFound();
            }

            _context.Bloco.Remove(bloco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlocoExists(int id)
        {
            return _context.Bloco.Any(e => e.BlocoId == id);
        }
    }
}

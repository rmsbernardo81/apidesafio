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
    public class CondominioController : ControllerBase
    {
        private readonly WebApiTesteDesafioContext _context;

        public CondominioController(WebApiTesteDesafioContext context)
        {
            _context = context;
        }

        // GET: api/Condominios
        [HttpGet]
        //public async Task<List<Condominio>> GetCondominio()
        public async Task<ActionResult<IEnumerable<Condominio>>> GetCondominio()
        {
            return await _context.Condominio
                .Include( r => r.Blocos)
                .ThenInclude(r => r.Apartamentos)
                .ThenInclude(r => r.Moradores)
                .ToListAsync();
        }

        // GET: api/Condominios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condominio>> GetCondominio(int id)
        {
            var condominio = await _context.Condominio
                .Include(r => r.Blocos)
                .ThenInclude(r => r.Apartamentos)
                .ThenInclude(r => r.Moradores)
                .FirstOrDefaultAsync(i => i.CondominioId == id);

            if (condominio == null)
            {
                return NotFound();
            }

            return condominio;
        }

        // PUT: api/Condominios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondominio(int id, string nome, string email, string telefone)
        {
            var condominio = new Condominio { Nome = nome, Email = email, Telefone = telefone };

            if(id < 0)
            {
                return BadRequest();
            }

            _context.Entry(condominio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondominioExists(id))
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

        // POST: api/Condominios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condominio>> PostCondominio(string nome, string email, string telefone)
        {
            var condominio = new Condominio { Nome = nome, Email = email, Telefone = telefone };
            _context.Condominio.Add(condominio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondominio", new { id = condominio.CondominioId }, condominio);
        }

        // DELETE: api/Condominios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondominio(int id)
        {
            var condominio = await _context.Condominio.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }

            _context.Condominio.Remove(condominio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondominioExists(int id)
        {
            return _context.Condominio.Any(e => e.CondominioId == id);
        }
    }
}

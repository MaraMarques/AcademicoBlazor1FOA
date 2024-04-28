using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InstituicaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Instituicaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instituicao>>> GetInstituicoes()
        {
            return await _context.Instituicoes.ToListAsync();
        }

        // GET: api/Instituicaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituicao>> GetInstituicao(int id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return instituicao;
        }

        // PUT: api/Instituicaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstituicao(int id, Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return BadRequest();
            }

            _context.Entry(instituicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituicaoExists(id))
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

        // POST: api/Instituicaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instituicao>> PostInstituicao(Instituicao instituicao)
        {
            _context.Instituicoes.Add(instituicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstituicao", new { id = instituicao.InstituicaoID }, instituicao);
        }

        // DELETE: api/Instituicaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstituicao(int id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstituicaoExists(int id)
        {
            return _context.Instituicoes.Any(e => e.InstituicaoID == id);
        }
    }
}

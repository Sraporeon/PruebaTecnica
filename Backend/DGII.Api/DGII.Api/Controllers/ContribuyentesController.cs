using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DGII.Api.Data;
using DGII.Api.Models;

namespace DGII.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContribuyentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Contribuyentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribuyente>>> GetContribuyentes()
        {
            return await _context.Contribuyentes.ToListAsync();
        }

        // GET: api/Contribuyentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuyente>> GetContribuyente(string id)
        {
            var contribuyente = await _context.Contribuyentes.FindAsync(id);

            if (contribuyente == null)
            {
                return NotFound();
            }

            return contribuyente;
        }

        // PUT: api/Contribuyentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribuyente(string id, Contribuyente contribuyente)
        {
            if (id != contribuyente.RncCedula)
            {
                return BadRequest();
            }

            _context.Entry(contribuyente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContribuyenteExists(id))
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

        // POST: api/Contribuyentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contribuyente>> PostContribuyente(Contribuyente contribuyente)
        {
            _context.Contribuyentes.Add(contribuyente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContribuyenteExists(contribuyente.RncCedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContribuyente", new { id = contribuyente.RncCedula }, contribuyente);
        }

        // DELETE: api/Contribuyentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContribuyente(string id)
        {
            var contribuyente = await _context.Contribuyentes.FindAsync(id);
            if (contribuyente == null)
            {
                return NotFound();
            }

            _context.Contribuyentes.Remove(contribuyente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContribuyenteExists(string id)
        {
            return _context.Contribuyentes.Any(e => e.RncCedula == id);
        }
    }
}

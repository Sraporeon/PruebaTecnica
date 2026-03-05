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
    public class ComprobanteFiscalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComprobanteFiscalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ComprobanteFiscals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprobanteFiscal>>> GetComprobantesFiscales()
        {
            return await _context.ComprobantesFiscales.ToListAsync();
        }

        // GET: api/ComprobanteFiscals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComprobanteFiscal>> GetComprobanteFiscal(string id)
        {
            var comprobanteFiscal = await _context.ComprobantesFiscales.FindAsync(id);

            if (comprobanteFiscal == null)
            {
                return NotFound();
            }

            return comprobanteFiscal;
        }

        // PUT: api/ComprobanteFiscals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprobanteFiscal(string id, ComprobanteFiscal comprobanteFiscal)
        {
            if (id != comprobanteFiscal.RncCedula)
            {
                return BadRequest();
            }

            _context.Entry(comprobanteFiscal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobanteFiscalExists(id))
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

        // POST: api/ComprobanteFiscals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComprobanteFiscal>> PostComprobanteFiscal(ComprobanteFiscal comprobanteFiscal)
        {
            _context.ComprobantesFiscales.Add(comprobanteFiscal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComprobanteFiscalExists(comprobanteFiscal.RncCedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComprobanteFiscal", new { id = comprobanteFiscal.RncCedula }, comprobanteFiscal);
        }

        // DELETE: api/ComprobanteFiscals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprobanteFiscal(string id)
        {
            var comprobanteFiscal = await _context.ComprobantesFiscales.FindAsync(id);
            if (comprobanteFiscal == null)
            {
                return NotFound();
            }

            _context.ComprobantesFiscales.Remove(comprobanteFiscal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprobanteFiscalExists(string id)
        {
            return _context.ComprobantesFiscales.Any(e => e.RncCedula == id);
        }
    }
}

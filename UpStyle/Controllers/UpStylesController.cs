using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkerService1.Data;
using WorkerService1.Models;
using WorkerService1.Services;

namespace WorkerService1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpStyleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UpStyleController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var upStyles = await _context.UpStyles.ToListAsync();
            return Ok(upStyles);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var upStyle = await _context.UpStyles.FindAsync(id);
            if (upStyle == null)
            {
                return NotFound();
            }
            return Ok(upStyle);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpStyle upStyle)
        {
            if (!CnpjValidator.IsValidCnpj(upStyle.Cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UpStyles.Add(upStyle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = upStyle.UpStyleId }, upStyle);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpStyle upStyle)
        {
            if (id != upStyle.UpStyleId)
            {
                return BadRequest();
            }

            if (!CnpjValidator.IsValidCnpj(upStyle.Cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            _context.Entry(upStyle).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpStyleExists(id))
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
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var upStyle = await _context.UpStyles.FindAsync(id);
            if (upStyle == null)
            {
                return NotFound();
            }

            _context.UpStyles.Remove(upStyle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UpStyleExists(int id)
        {
            return _context.UpStyles.Any(e => e.UpStyleId == id);
        }
    }
}

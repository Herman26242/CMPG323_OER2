using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Algo_Rhythoms.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMPG323_OER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OERWebsiteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OERWebsiteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OERWebsite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OERWebsite>>> GetOERWebsites()
        {
            return await _context.OERWebsites.ToListAsync();
        }

        // GET: api/OERWebsite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OERWebsite>> GetOERWebsite(int id)
        {
            var website = await _context.OERWebsites.FindAsync(id);
            if (website == null)
            {
                return NotFound();
            }

            return website;
        }

        // POST: api/OERWebsite
        [HttpPost]
        public async Task<ActionResult<OERWebsite>> PostOERWebsite(OERWebsite website)
        {
            _context.OERWebsites.Add(website);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOERWebsite), new { id = website.ID }, website);
        }

        // PUT: api/OERWebsite/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOERWebsite(int id, OERWebsite website)
        {
            if (id != website.ID)
            {
                return BadRequest();
            }

            _context.Entry(website).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OERWebsiteExists(id))
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

        // DELETE: api/OERWebsite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOERWebsite(int id)
        {
            var website = await _context.OERWebsites.FindAsync(id);
            if (website == null)
            {
                return NotFound();
            }

            _context.OERWebsites.Remove(website);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OERWebsiteExists(int id)
        {
            return _context.OERWebsites.Any(e => e.ID == id);
        }
    }
}

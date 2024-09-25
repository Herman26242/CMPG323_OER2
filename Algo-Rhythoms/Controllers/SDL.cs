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
    public class SDLController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SDLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SDL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SDL>>> GetSDLs()
        {
            return await _context.SDL.ToListAsync();
        }

        // GET: api/SDL/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SDL>> GetSDL(int id)
        {
            var resource = await _context.SDL.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return resource;
        }

        // POST: api/SDL
        [HttpPost]
        public async Task<ActionResult<SDL>> PostSDL(SDL resource)
        {
            _context.SDL.Add(resource);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSDL), new { id = resource.ID }, resource);
        }

        // PUT: api/SDL/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSDL(int id, SDL resource)
        {
            if (id != resource.ID)
            {
                return BadRequest();
            }

            _context.Entry(resource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SDLExists(id))
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

        // DELETE: api/SDL/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSDL(int id)
        {
            var resource = await _context.SDL.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            _context.SDL.Remove(resource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SDLExists(int id)
        {
            return _context.SDL.Any(e => e.ID == id);
        }
    }
}

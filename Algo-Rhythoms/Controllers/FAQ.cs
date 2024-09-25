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
    public class FAQController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FAQController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/faq
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FAQ>>> GetFAQs()
        {
            return await _context.FAQ.ToListAsync();
        }

        // POST: api/faq
        [HttpPost]
        public async Task<ActionResult<FAQ>> PostFAQ(FAQ faq)
        {
            faq.CreatedBy = 13; // Default CreatedBy to user 13
            faq.UpdatedBy = 13; // Default UpdatedBy to user 13

            _context.FAQ.Add(faq);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFAQs), new { id = faq.FAQID }, faq);
        }

        // PUT: api/faq/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFAQ(int id, FAQ faq)
        {
            if (id != faq.FAQID)
            {
                return BadRequest();
            }

            faq.UpdatedBy = 13; // Default UpdatedBy to user 13
            _context.Entry(faq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FAQExists(id))
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

        // DELETE: api/faq/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFAQ(int id)
        {
            var faq = await _context.FAQ.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }

            _context.FAQ.Remove(faq);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FAQExists(int id)
        {
            return _context.FAQ.Any(e => e.FAQID == id);
        }
    }
}

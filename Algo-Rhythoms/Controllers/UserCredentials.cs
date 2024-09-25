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
    public class UserCredentialsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserCredentialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCredentials/User/{userId}
        [HttpGet("User/{userId}")]
        public async Task<ActionResult<IEnumerable<UserCredential>>> GetUserCredentialsByUserId(int userId)
        {
            var userCredentials = await _context.UserCredentials
                .Where(uc => uc.UserID == userId)
                .ToListAsync();

            if (userCredentials == null || !userCredentials.Any())
            {
                return NotFound();
            }

            return userCredentials;
        }

        // POST: api/UserCredentials/User/{userId}
        [HttpPost("User/{userId}")]
        public async Task<ActionResult<IEnumerable<UserCredential>>> PostUserCredentials(int userId, [FromBody] List<string> credentials)
        {
            if (credentials == null || !credentials.Any())
            {
                return BadRequest("No credentials provided.");
            }

            var userCredentials = new List<UserCredential>();

            foreach (var credential in credentials)
            {
                userCredentials.Add(new UserCredential
                {
                    UserID = userId, // Assign the UserID from the route
                    Credential = credential // Set the credential from the list
                });
            }

            _context.UserCredentials.AddRange(userCredentials);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserCredentialsByUserId), new { userId = userId }, userCredentials);
        }




        // DELETE: api/UserCredentials/User/{userId}
        [HttpDelete("User/{userId}")]
        public async Task<IActionResult> DeleteUserCredentialsByUserId(int userId)
        {
            var userCredentials = await _context.UserCredentials
                .Where(uc => uc.UserID == userId)
                .ToListAsync();

            if (userCredentials == null || !userCredentials.Any())
            {
                return NotFound();
            }

            _context.UserCredentials.RemoveRange(userCredentials);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

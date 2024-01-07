using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sn_aspreact.Data;
using sn_aspreact.Models;
using System.Security.Claims;
using static sn_aspreact.HelperMethods;
namespace sn_aspreact.Controllers
{
    [Route("api/[controller]")]
    //[Route("/")]
    [ApiController]
    public class EditProfileController : ControllerBase
    {
        private ApplicationDbContext _context;

        public EditProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize]
        public ActionResult<EditUser> GetUser()
        {
            var user = _context.GetAutherizedUser(HttpContext);
            if (user == null)
            {
                return Unauthorized();
            }
            return new EditUser(user);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> PutUser(ApplicationUser user)
        {
            var author = _context.GetAutherizedUser(HttpContext);
            if (author == null) return Unauthorized();
            author.Name = user.Name;
            author.NameNormalized = user.NameNormalized;
            author.FullName = user.FullName;
            author.Email = user.Email;
            author.NormalizedEmail= user.NormalizedEmail;
            author.ProfileImage = user.ProfileImage;
            _context.Users.Entry(author).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}

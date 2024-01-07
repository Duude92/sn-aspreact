using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sn_aspreact.Data;
using sn_aspreact.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sn_aspreact.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ProfileController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET api/<ProfileController>/userName
		[HttpGet("{name}")]
		public async Task<ActionResult<PublicUser>> Get(string name)
		{
			var userName = name.ToUpper();
			var user = _context.Users.Where(user => user.NameNormalized == userName).Select(user => new PublicUser(user)).FirstOrDefault();
			if (user == null)
			{
				return NotFound();
			}
			user.posts = await _context.Posts.Where(post => post.UserId == user.Id).Include(post => post.url).Select(post => new SendPostModel(post)).ToArrayAsync();
			return user;
		}
	}
}

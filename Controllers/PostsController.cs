using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sn_aspreact.Data;
using sn_aspreact.Models;
using System.Timers;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic;
using static sn_aspreact.HelperMethods;

namespace sn_aspreact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SendPostModel>>> GetPosts()
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            return await _context.Posts.Include(a => a.Author).Include(a=>a.url).Select(i =>  new SendPostModel(i)).ToListAsync();
        }
   

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SendPostModel>> GetPostModel(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var postModel = await _context.Posts.FindAsync(id);
            


            if (postModel == null)
            {
                return NotFound();
            }
            postModel.Author = await _context.Users.FindAsync(postModel.UserId);
            await _context.Entry(postModel).Collection(pm => pm.url).LoadAsync();

            SendPostModel result = new SendPostModel(postModel);
            result.Answers = await _context.Posts.Where(post => post.AnswerId == result.ID).Include(a=>a.Author).Include(a => a.url).Select(post=>new SendPostModel(post)).ToArrayAsync();

            return result;
        }
        //private PostModel[] GetAnswer(postmodel)

        // PUT: api/Post/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutPostModel(int id, PostModel postModel)
        {
            if (id != postModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(postModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostModelExists(id))
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

        // POST: api/Post
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostModel>> PostPostModel(PostModel postModel)
        {
            
            if (_context.Posts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Posts'  is null.");
            }
            postModel.CreatedAt = DateTime.Now;
            var author = _context.GetAutherizedUser(HttpContext);
            var user = this.User;
            //var author = await _context.Users.FindAsync(postModel.AspUserId);
            if (author == null)
            {
                return Unauthorized();
            }
            postModel.UserId = author.Id;
            _context.Posts.Add(postModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostModel", new { id = postModel.ID }, postModel);
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostModel(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var postModel = await _context.Posts.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(postModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostModelExists(int id)
        {
            return (_context.Posts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

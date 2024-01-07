using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using sn_aspreact.Data;
using System.Drawing;
using System.IO;
using System.Security.Policy;

namespace sn_aspreact.Controllers
{
	/// <summary>
	/// Simulation of CDN server, not necessary in real project
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ContentController : ControllerBase
	{
		public const string fileUploadPath = "d:\\eben\\";
		ApplicationDbContext _context;
		public ContentController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("{name}")]
		public ActionResult GetContent(string name)
		{
			if (!System.IO.File.Exists(fileUploadPath + name))
				return NoContent();
			var binary = System.IO.File.ReadAllBytes(fileUploadPath + name);

			var file = base.File(binary, "image/jpeg");
			return file;
		}
		[HttpGet("contentID")]
		public async Task<ActionResult> GetContentById(string contentid)
		{
			var url = await _context.UrlContents.FindAsync(contentid);
			return (url == null) ? NotFound() : GetContent(System.IO.Path.GetFileName(url.URL));
		}
	}
}

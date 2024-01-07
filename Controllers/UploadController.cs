using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using sn_aspreact.Models;
using System.Net.Http;
using System.Web;

namespace sn_aspreact.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UploadController : ControllerBase
	{
		[HttpPost, Consumes("multipart/form-data")]
		public async Task<ActionResult<LinksModel>> PostData([FromForm] List<IFormFile> files)
		{
			LinksModel links = new LinksModel();
			List<string> urls = new List<string>();
			if (files.Count == 0) return NoContent();

			foreach (var file in files)
			{
				var fileExt = file.FileName.Split('.').Last();
				var filePath = file.GetHashCode() + "." + fileExt;
				using (var stream = System.IO.File.Create(ContentController.fileUploadPath + filePath))
				{
					await file.CopyToAsync(stream);
				}
				urls.Add(filePath);
			}
			links.Links = urls;
			return links;
		}
	}
}

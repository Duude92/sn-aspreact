using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace sn_aspreact.Models
{
	public class UrlContentModel
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string ID { get; set; }
		[Required]
		public string URL { get; set; }
		//[BindNever]
		//public PostModel PostModel { get; set; }
	}
}

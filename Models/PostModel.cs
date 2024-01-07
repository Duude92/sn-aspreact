using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace sn_aspreact.Models
{
    public class PostModel
    {
        [Key]
        public int ID { get; set; }
        [Required, Column(TypeName = "nvarchar(2000)")]
        public string PostMessage { get; set; } = "";
        [Required]
        public ContentType ContentType { get; set; }
        public List<UrlContentModel> url { get; set; }
        [BindNever]
        public DateTime? CreatedAt { get; set; }
        [BindNever, IgnoreDataMember, JsonIgnore]
        public string? UserId { get; set; }
        [ForeignKey("UserId"), BindNever, IgnoreDataMember, JsonIgnore]
        public ApplicationUser? Author { get; set; }
        public int? AnswerId { get; set; }
        [ForeignKey("AnswerId"), BindNever, IgnoreDataMember, JsonIgnore]
        public PostModel? Answer { get; set; }

    }
    public class SendPostModel : PostModel
    {
        public SendPostModel(PostModel model)
        {
            this.ID = model.ID;
            this.PostMessage = model.PostMessage;
            this.ContentType = model.ContentType;
            this.url = model.url;
            this.CreatedAt = model.CreatedAt;
            this.UserId = model.UserId;
            this.Author = model.Author;
            this.AnswerId = model.AnswerId;
        }

        [NotMapped, BindNever]
        public string? AuthorName => Author != null ? Author.Name : "None";
        [NotMapped, BindNever]
        public string? AuthorFullName => Author != null ? Author.FullName : "None";
        [NotMapped, BindNever]
        public string? AuthorPicture => Author != null ? Author.ProfileImage : "None";
        public SendPostModel[]? Answers { get; set; }

    }
    //public class ReceivePostModel : PostModel
    //{
    //    [BindNever, IgnoreDataMember, NotMapped]
    //    public string AspUserId { get; set; }

    //}

    public enum ContentType
    {
        NONE,
        PICTURE,
        VIDEO,
        MUSIC,
        LINK,
        STREAM,
    }
}

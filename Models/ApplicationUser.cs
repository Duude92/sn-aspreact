using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace sn_aspreact.Models;

public class ApplicationUser : IdentityUser
{
	public string? ProfileImage { get; set; }
    public string Name { get; set; }
    public string NameNormalized { get; set; }
    public string? FullName { get; set; }

}
public class AppUser
{
    public string UserName { get; set; }
    public string? FullName { get; set; }
    public string? ProfileImage { get; set; }
    [JsonIgnore]
    public string Id { get; set; }
    public AppUser(ApplicationUser user)
    {
        this.Id = user.Id;
        this.UserName = user.Name;
        this.FullName = user.FullName;
        this.ProfileImage = user.ProfileImage;
    }
}
public class PublicUser : AppUser
{
    public SendPostModel[] posts { get; set; }

    public PublicUser(ApplicationUser user) : base(user)
    {

    }

}
public class EditUser : AppUser
{
    public string Email { get; set; }
    public EditUser(ApplicationUser user) : base(user)
    {
        this.Email = user.Email;
    }

}

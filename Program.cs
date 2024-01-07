using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using sn_aspreact;
using sn_aspreact.Data;
using sn_aspreact.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using static sn_aspreact.HelperMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
	options.SignIn.RequireConfirmedAccount = true;
    })
	.AddEntityFrameworkStores<ApplicationDbContext>();


//builder.Services.AddDefaultIdentity1<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddIdentityServer()
	.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication().AddIdentityServerJwt();
//builder.Services.AddAuthentication().AddJwtBearer();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//builder.Services.AddSwaggerGen(options =>
//{
//	options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger API", Version = "V1" });
//	options.OperationFilter<SwaggerHeaderFilter>();
//});


//var origin = "https://localhost:44405/";
var app = builder.Build();
app.UseCors(options =>
options.SetIsOriginAllowed(origin => true).AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	//app.UseSwagger();
	//app.UseSwaggerUI();

}
else
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();

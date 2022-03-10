using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using BotanicaStoreBack.Services;
using BotanicaStoreBack.Services.Mailer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Issuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
	};
});

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddTransient<UserDb>();
builder.Services.AddTransient<PlantDb>();
builder.Services.AddTransient<PlantPriceDb>();
builder.Services.AddTransient<vwListedPlantDb>();
builder.Services.AddTransient<PlantPricingDb>();
builder.Services.AddTransient<WishListDb>();
builder.Services.AddTransient<CalendarDb>();
builder.Services.AddTransient<vwWishListEmailDb>();
builder.Services.AddTransient<LinkDb>();
builder.Services.AddTransient<vwShoppingListSummaryDb>();

builder.Services.AddHttpClient<MailgunService>();

builder.Services.AddControllers();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseHttpsRedirection();
}

app.Use(async (context, next) =>
{
	await next();

	var path = context.Request.Path.Value;
	bool notApi = !path.StartsWith("/api");
	bool noExt = !Path.HasExtension(path);

	if (notApi && noExt)
	{
		context.Request.Path = "/index.html";
		await next();
	}
});

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".html"] = "text/html";
provider.Mappings[".webmanifest"] = "application/manifest+json";

app.UseStaticFiles(new StaticFileOptions()
{
	ContentTypeProvider = provider
});

app.UseRouting();

if (app.Environment.IsDevelopment())
	app.UseCors(builder =>
	{
		builder
		.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
	});

app.UseAuthentication();
app.UseAuthorization();

Settings.AppSettings = app.Services.GetService<AppSettings>();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();



using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack
{
	public class Startup
	{
		string allowedOrigins = "AllowedOrigins";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(allowedOrigins,
					builder =>
					{
						builder.WithOrigins("https://botanicaplants.com",
																"https://www.botanicaplants.com",
																"http://localhost:5050")
																.AllowAnyHeader()
																.AllowAnyMethod();
					});
			});


			services.Configure<AppSettings>(Configuration);

			services.AddControllers();
			//services.AddHttpClient();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

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
			app.UseCors(allowedOrigins);

			app.UseAuthorization();

			Settings.AppSettings = app.ApplicationServices.GetService<AppSettings>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

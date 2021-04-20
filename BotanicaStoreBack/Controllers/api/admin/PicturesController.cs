﻿using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BotanicaStoreBack.Controllers.api.admin
{
	[Route("api/admin/[controller]")]
	[AdminAuthorize]
	[ApiController]
	public class PicturesController : ControllerBase
	{
    private readonly AppSettings opts;
    private readonly PlantDb db;

		public PicturesController(IOptions<AppSettings> options, IPlantDb db)
		{
      opts = options.Value;
			this.db = (PlantDb)db;
		}


		// POST api/admin/Pictures/SavePicture
		[HttpPost("[action]")]
		public ActionResult SavePicture()
		{
      try
      {
        var file = Request.Form.Files[0];
        int plantId = Int32.Parse(Request.Form["plantId"].FirstOrDefault());
        bool isSmall = Request.Form["type"].FirstOrDefault() == "sm";

        if (file.Length > 0)
        {
          string dir = Directory.GetCurrentDirectory();

          if (opts.IsDev)
            dir = dir.Replace(@"BotanicaStoreBack\BotanicaStoreBack", @"BotanicaStoreFront\public\plantpics");

          //C:\Users\B\Documents\AppDev\BotanicaStoreBack\BotanicaStoreBack
          //C:\Users\B\Documents\AppDev\BotanicaStoreFront\public\plantpics

          string picId;
          if (isSmall)
            picId = "sm";
				  else
            picId = db.GetNextBigPicId(plantId);

          string fileName = $"p{plantId.ToString("0000")}_{picId.PadLeft(2, '0')}.jpg";
          string fullPath = Path.Combine(dir, fileName);

					using (var stream = new FileStream(fullPath, FileMode.Create))
						file.CopyTo(stream);

          var ppid = new PlantPicId { PlantId = plantId, PicId = picId };

          db.UpdatePictures(ppid);

					return Ok(ppid);
        }
        else
        {
          return BadRequest();
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex}");
      }

    }

		// POST api/admin/Pictures/SavePicture
		[HttpPost("[action]")]
		public ActionResult DeletePicture([FromBody] PlantPicId ppid)
		{
      string dir = Directory.GetCurrentDirectory();

      if (opts.IsDev)
        dir = dir.Replace(@"BotanicaStoreBack\BotanicaStoreBack", @"BotanicaStoreFront\public\plantpics");

      string fileName = $"p{ppid.PlantId.ToString("0000")}_{ppid.PicId.PadLeft(2, '0')}.jpg";
      string fullPath = Path.Combine(dir, fileName);

      System.IO.File.Delete(fullPath);

      db.DeletePictures(ppid);

      return Ok(true);
    }
	}
}

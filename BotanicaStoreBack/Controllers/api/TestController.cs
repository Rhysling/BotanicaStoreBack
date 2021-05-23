using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using BotanicaStoreBack.Services.Mailer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace arc2d.Controllers.api
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {
    private MailgunService mailgunService;
    private vwWishListEmailDb db;
    private AppSettings settings;

    public TestController(MailgunService mailgunService, vwWishListEmailDb db, IOptions<AppSettings> opts)
		{
      this.mailgunService = mailgunService;
      this.db = db;
      settings = opts.Value;
		}

    [HttpGet("[action]")]
    [AdminAuthorize]
    public ActionResult GetClaims()
    {
      var user = HttpContext.User;
      var claims = String.Join(' ', user.Claims.Select(a => $"{a.Type}={a.Value}"));
      return Ok(new { Msg = claims });
    }

    [HttpGet("[action]")]
    public async Task<string> SendTestMessage()
    {
      await mailgunService.SendTestMessage();
      return "Done.";
    }

    [HttpGet("[action]")]
    public string CurrentDirectory()
    {
      return Directory.GetCurrentDirectory();
    }

    [HttpGet("[action]")]
    public ContentResult MsgHtml()
    {
      var wle = db.GetByWlId(1);
      var wlm = new WishListMessage(wle, settings.TaxRate);

      return new ContentResult {
        ContentType = "text/html",
        StatusCode = 200,
        Content = wlm.RenderHtmlBody()
      };
    }

    [HttpGet("[action]")]
    public ContentResult MsgText()
    {
      var wle = db.GetByWlId(1);
      var wlm = new WishListMessage(wle, settings.TaxRate);

      return new ContentResult
      {
        ContentType = "text/text",
        StatusCode = 200,
        Content = wlm.RenderTextBody()
      };
    }

  }
}
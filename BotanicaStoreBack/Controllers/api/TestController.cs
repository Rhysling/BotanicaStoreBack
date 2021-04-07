using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arc2d.Controllers.api
{
  [Route("api/[controller]")]
  [AdminAuthorize]
  [ApiController]
  public class TestController : ControllerBase
  {

    [HttpGet]
    public ActionResult Get()
    {
      var user = HttpContext.User;

      var claims = String.Join(' ', user.Claims.Select(a => $"{a.Type}={a.Value}"));

      return Ok(new { Msg = claims });
    }

  }
}
﻿using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
    private readonly AppSettings opts;
    private readonly UserDb db;

    public LoginController(IOptions<AppSettings> options, IUserDb db)
    {
      opts = options.Value;
      this.db = (UserDb)db;
    }


    // POST api/<LoginController>
    [AllowAnonymous]
		[HttpPost]
		public IActionResult Post([FromBody] UserLogin login)
		{
      IActionResult response = Unauthorized();
      var user = AuthenticateUser(login);

      if (user != null)
      {
        var tokenString = GenerateJSONWebToken(user);
        response = Ok(new { token = tokenString });
      }

      return response;
    }


    private User AuthenticateUser(UserLogin login)
    {
      if (login.Email is null)
        return null;

      // isValidEmail = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/.test(email);
      if (!Regex.IsMatch(login.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
        return null;

      User user = db.FindByEmail(login.Email);
      bool isAmin = login.Email.EndsWith("polson.com");

      if (isAmin && ((user is null) || (login.Pw != opts.AdminPw)))
        return null;

      if (user is null)
      {
        user = new User {
          Email = login.Email,
          FullName = String.IsNullOrWhiteSpace(login.FullName) ? null : login.FullName,
          IsAdmin = false,
          CreatedDate = DateTime.Now,
          LastLoginDate = DateTime.Now,
          LoginCount = 1
        };
      }
			else
			{
        if (!String.IsNullOrWhiteSpace(login.FullName))
          user.FullName = login.FullName;

        user.LastLoginDate = DateTime.Now;
        user.LoginCount += 1;
			}

      db.Save(user);

      return user;
    }

    private string GenerateJSONWebToken(User user)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opts.Jwt.Key));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new[] {
        new Claim("Email", user.Email),
        new Claim("FullName", user.FullName),
        new Claim("IsAdmin", user.IsAdmin.ToString())
      };

      var token = new JwtSecurityToken(opts.Jwt.Issuer,
          opts.Jwt.Issuer,
          claims,
          expires: DateTime.Now.AddMinutes(120),
          signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

  }
}
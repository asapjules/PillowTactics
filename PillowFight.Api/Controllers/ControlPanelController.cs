﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PillowFight.Api.Models;
using PillowFight.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PillowFight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ControlPanelController : ControllerBase
    {
        readonly IPlayerBL _playerBL;

        public ControlPanelController(IServiceProvider serviceProvider)
        {
            _playerBL = serviceProvider.GetRequiredService<IPlayerBL>();
        }

        [HttpGet("Characters")]
        public async Task<ActionResult<IEnumerable<PlayerCharacter>>> GetCharacters()
        {
            throw new NotImplementedException();
            //var characters = await _playerBL.GetPlayerCharactersAsync(Convert.ToInt32(User.Claims.FirstOrDefault().Value));
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}

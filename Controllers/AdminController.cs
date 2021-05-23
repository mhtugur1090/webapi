using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SahinKereste.DTOs;
using SahinKereste.Entity;
using SahinKereste.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdminController:ControllerBase
    {
        
        private UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        [HttpPut("repassword")]
        public async Task<IActionResult> updateAdmin(AdminChangePassDTO model) // AdminChangePassDTO : username , password,newPassword
        {
            var _user = await _userManager.FindByNameAsync(model.UserName);

            var result = await _userManager.ChangePasswordAsync(_user, model.Password, model.newPassword);

            if (!result.Succeeded)
            {
                string errors = "";

                foreach (var item in result.Errors)
                {
                    errors += item.Description;
                }
                return BadRequest(errors);
            }

            return Ok(model);

        }

    }
}

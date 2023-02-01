
using Helper.Business.Users;
using Helper.Business.Users.Dtos;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private UserManager<ApplicationUser> _userManager;


        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;

        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users.Count == 0)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
            else
            {
                return Ok(users);
            }

        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUser()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if(currentUser !=null)
            {
                var user = await _userService.GetUser(currentUser.Id);

                if (user != null)
                {
                    return Ok(user);
                }
            }
            return NotFound("Kullanıcı Bulunamadı");

        }


        [HttpGet]
        [Route("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(string id)
        {
            if(id != null)
            {
                var user = await _userService.GetUser(id);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            return NotFound("Kullanıcı Bulunamadı");
        }

       

        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateApplicationUserDto model)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var result = await _userService.UpdateUser(currentUser, model);
            if (result.Succeeded)
            {
                return Ok("Bilgiler Başarıyla Güncellendi");
            }
            return NotFound("Bilgiler Güncellenemedi");
        }



        [HttpDelete]
        [Route("[action]")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteUser()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var result = await _userService.DeleteUser(currentUser.Id);
            if (result.Succeeded)
            {
                return Ok("Kulanıcı Başarıyla Silindi");
            }
            return NotFound("Kulanıcı Silinemedi");
        }

    }
}

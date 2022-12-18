
using Helper.Business.Users;
using Helper.Business.Users.Dtos;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//Validation kontrolu yapildi
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userService.GetAllUsers();

            if (user.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }

        /// <summary>
        /// Get User By ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var createUser = await _userService.CreateUser(user);
            return CreatedAtAction("GetUserById", new { id = createUser.UserID }, createUser);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (await _userService.GetUserById(user.UserID) != null)
            {
                return Ok(await _userService.UpdateUser(user));
            }
            return NotFound();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _userService.GetUserById(id) != null)
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        [Route("User")]
        public async Task<ActionResult> UserCreate([FromBody] UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.UserName.Trim(),
                    Email = model.Email.Trim()
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password.Trim());
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("User").Result)
                    {
                        ApplicationRole role = new ApplicationRole()
                        {
                            Name = "User"
                        };
                        IdentityResult roleResult = await _roleManager.CreateAsync(role);
                        if (roleResult.Succeeded)
                        {
                            _userManager.AddToRoleAsync(user, "User").Wait();
                        }
                    }
                    _userManager.AddToRoleAsync(user, "User").Wait();
                    return Ok();
                }
                String errorMessage = String.Empty;
                foreach (var item in result.Errors)
                {
                    errorMessage += item.Description;
                }
                return BadRequest(errorMessage);
            }
            return BadRequest("Bilgilerinizi kontrol ediniz. İstenilen formatta değil");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(model.UserName.Trim());
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password.Trim()))
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                    var token = new JwtSecurityToken(
                        issuer: "http://google.com",
                        audience: "http://google.com",
                        expires: DateTime.UtcNow.AddHours(1),
                        claims: claims,
                        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else
                {
                    return BadRequest("Giriş bilgilerinizi kontrol edin hatalı gözüküyor.");
                }
            }
            return BadRequest("Veriler uygun değil");
        }
    }
}


using Helper.Business.Users;
using Helper.Entites.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Helper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//Validation kontrolu yapildi
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
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

    }
}

using Helper.Business.Helps;
using Helper.Business.Users;
using Helper.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Helper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpsController : ControllerBase
    {
        private IHelpService _helpService;
        private IUserService _userService;


        public HelpsController(IHelpService helpService, IUserService userService)
        {
            _helpService = helpService;
            _userService = userService;
        }

        /// <summary>
        /// Get All Helps
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllHelps()
        {
            var help = await _helpService.GetAllHelps();

            if(help.Count == 0)
            {
                return NotFound();
            }
            return Ok(help);
        }

        /// <summary>
        /// Get Help By ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHelpById(int id)
        {
            var help = await _helpService.GetHelpById(id);
            if (help != null)
            {
                return Ok(help);
            }
            return NotFound();
        }

        /// <summary>
        /// Create Help
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHelp([FromBody] Help help)
        {
            var createHelp = await _helpService.CreateHelp(help);
            //var user = createHelp.User;
           
            return CreatedAtAction("GetHelpById", new { id = createHelp.HelpId }, createHelp);
        }

        /// <summary>
        /// Update Help
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHelp([FromBody] Help help)
        {
            if (await _helpService.GetHelpById(help.HelpId) != null)
            {
                return Ok(await _helpService.UpdateHelp(help));
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Help
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _helpService.GetHelpById(id) != null)
            {
                await _helpService.DeleteHelp(id);
                return Ok();
            }
            return NotFound();
        }
    }


}

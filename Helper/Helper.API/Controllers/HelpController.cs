using Helper.Business.Answers.Dtos;
using Helper.Business.Helps;
using Helper.Business.Helps.Dtos;
using Helper.Business.Users;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
//using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace Helper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpController : ControllerBase
    {
        private readonly IHelpService _helpService;
        private readonly IUserService _userService;

        private readonly UserManager<ApplicationUser> _userManager;


        public HelpController(IHelpService helpService, IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _helpService = helpService;
            _userService = userService;
            _userManager= userManager;
        }

        /// <summary>
        /// Get All Helps
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllHelps()
        {
            var helps = await _helpService.GetAllHelps();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(helps);
        }





        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUserHelps()
        {
            var user = await _userManager.GetUserAsync(User);
            var helps = await _helpService.GetAllUserHelps(user.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(helps);
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
        public async Task<IActionResult> CreateHelp([FromBody] CreateHelpDto createHelpDto)
        {
            var user = await _userManager.GetUserAsync(User);
            await _helpService.CreateHelp(user.Id, createHelpDto);

            return Ok();

        }


        /// <summary>
        /// Delete Help
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHelp(int id)
        {
            if (await _helpService.GetHelpById(id) != null)
            {
                var user = await _userManager.GetUserAsync(User);
                await _helpService.DeleteHelp(user.Id, id);
                return Ok();
            }
            return NotFound();
        }



        /// <summary>
        /// Update Help
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHelp([FromBody] UpdateHelpDto updateHelpDto)
        {
            if (await _helpService.GetHelpById(updateHelpDto.HelpId) != null)
            {
                var user = await _userManager.GetUserAsync(User);
                await _helpService.UpdateHelp(user.Id, updateHelpDto);

                return Ok(updateHelpDto);
            }
            return BadRequest();
        }

        
    }


}

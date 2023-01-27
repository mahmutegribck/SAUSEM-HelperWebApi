using Helper.Business.Answers;
using Helper.Business.Answers.Dtos;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Helper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswersController : ControllerBase
    {

        private readonly IAnswerService _answerService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AnswersController(IAnswerService answerService, UserManager<ApplicationUser> userManager)
        {
            _answerService = answerService;
            _userManager = userManager;
        }

        /// <summary>
        /// Get All Answers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAnswers()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var answers = await _answerService.GetAllAnswers();

            return Ok(answers);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUserAnswers()
        {
            var user = await _userManager.GetUserAsync(User);
            var answers = await _answerService.GetAllUserAnswers(user.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(answers);
        }


        /// <summary>
        /// Get Answer By ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var answer = await _answerService.GetAnswerById(id);
            if (answer != null)
            {
                return Ok(answer);
            }

            return NotFound();
        }


        /// <summary>
        /// Create Answer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAnswer([FromBody] CreateAnswerDto createAnswerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.GetUserAsync(User);
            //createAnswerDto.IdentityUserId = user.Id;
            await _answerService.CreateAnswer(user.Id, createAnswerDto);
            //var user = createHelp.User;

            //return CreatedAtAction("GetHelpById", new { id = createHelp.HelpId }, createHelp);
            return Ok();
        }


        /// <summary>
        /// Delete Answer
        /// </summary>
        /// <returns></returns>

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            if (await _answerService.GetAnswerById(id) != null)
            {
                var user = await _userManager.GetUserAsync(User);
                await _answerService.DeleteAnswer(user.Id, id);
                return Ok();
            }
            return NotFound();

        }


        /// <summary>
        /// Update Answer
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerDto updateAnswerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _answerService.GetAnswerById(updateAnswerDto.AnswerId) != null)
            {
                var user = await _userManager.GetUserAsync(User);
                await _answerService.UpdateAnswer(user.Id, updateAnswerDto);

                return Ok(updateAnswerDto);

            }
            return BadRequest();
        }

        
    }
}



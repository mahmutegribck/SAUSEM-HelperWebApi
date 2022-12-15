using Helper.Business.Answers;
using Helper.Business.Answers.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Helper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {

        private IAnswerService _answerService;
        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        /// <summary>
        /// Get All Answers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAnswers()
        {

            var answers = await _answerService.GetAllAnswers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //if (answers.Count == 0)
            //{
            //    return NotFound();
            //}
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
        public async Task<IActionResult> CreateAnswer(int helpId, CreateAnswerDto createAnswerDto)
        {
            await _answerService.CreateAnswer(helpId, createAnswerDto);
            //var user = createHelp.User;

            //return CreatedAtAction("GetHelpById", new { id = createHelp.HelpId }, createHelp);
            return Ok();
        }

        /// <summary>
        /// Update Answer
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerDto updateAnswerDto)
        {
            if (await _answerService.GetAnswerById(updateAnswerDto.AnswerId) != null)
            {
                await _answerService.UpdateAnswer(updateAnswerDto);
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Answer
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {

            await _answerService.DeleteAnswer(id);
            return Ok();

        }
    }
}



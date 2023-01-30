using Helper.Business.Answers.Dtos;
using Helper.Business.Categories;
using Helper.Business.Categories.Dtos;
using Helper.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Helper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            //var categories = await _categoryService.GetAllCategories();

            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategory(createCategoryDto);

                return Ok();

            }
            return BadRequest(ErrorMsg.InvalidProperties);
           
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (await _categoryService.GetCategoryById(id) != null)
            { 
                await _categoryService.DeleteCategory(id);
                return Ok();
            }
            return NotFound();

        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _categoryService.GetCategoryById(updateCategoryDto.CategoryId) != null)
            {
                await _categoryService.UpdateCategory(updateCategoryDto);

                return Ok(updateCategoryDto);

            }
            return BadRequest();
        }
    }
}

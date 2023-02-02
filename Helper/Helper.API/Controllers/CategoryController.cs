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
    
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            if(categories.Count != 0)
            {
                return Ok(categories);
            }
            return NotFound("Kategori Bulunamadı");
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryById(int id)
       {
            var category = await _categoryService.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound("Kategori Bulunamadı");
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto.CategoryName !=null && createCategoryDto.CategoryName != "")
            {
                await _categoryService.CreateCategory(createCategoryDto);

                return Ok("Kategori Oluşturuldu");

            }
            return BadRequest("Kategori Eklenemedi");
           
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (await _categoryService.GetCategoryById(id) != null)
            { 
                await _categoryService.DeleteCategory(id);
                return Ok("Kategori Silindi");
            }
            return NotFound("Silinecek Kategori Bulunamadı");

        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
          
            if (await _categoryService.GetCategoryById(updateCategoryDto.CategoryId) != null)
            {
                await _categoryService.UpdateCategory(updateCategoryDto);

                return Ok("Kategori Güncellendi");

            }
            return BadRequest("Güncellenecek Kategori Bulunamadı");
        }
    }
}

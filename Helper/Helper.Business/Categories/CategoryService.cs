using AutoMapper;
using Helper.Business.Answers.Dtos;
using Helper.Business.Categories.Dtos;
using Helper.DataAccess.Answers;
using Helper.DataAccess.Categories;
using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }

        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category category = _mapper.Map<Category>(createCategoryDto);
            await _categoryRepository.CreateCategory(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }

        public async Task<List<GetCategoryDto>> GetAllCategories()
        {
            var categories = _mapper.Map<List<GetCategoryDto>>(await _categoryRepository.GetAllCategories());
            return categories.ToList();
        }

        public async Task<GetCategoryDto> GetCategoryById(int id)
        {
            if (id > 0)
            {
                var category = _mapper.Map<GetCategoryDto>(await _categoryRepository.GetCategorypById(id));
                return category;
            }
            else
            {
                throw new Exception("Id can not be less than 1");
            }
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category category = _mapper.Map<Category>(updateCategoryDto);
            await _categoryRepository.UpdateCategory(category);
        }
    }
}

using Helper.Business.Categories.Dtos;
using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Business.Categories
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetAllCategories();

        Task<GetCategoryDto> GetCategoryById(int id);

        Task CreateCategory(CreateCategoryDto createCategoryDto);

        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);

        Task DeleteCategory(int id);
    }
}

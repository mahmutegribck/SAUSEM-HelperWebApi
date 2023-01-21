using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Categories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();

        Task<Category> GetCategorypById(int id);

        Task CreateCategory(Category category);

        Task UpdateCategory(Category category);

        Task DeleteCategory(int id);
    }
}

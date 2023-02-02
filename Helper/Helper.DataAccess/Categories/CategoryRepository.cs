using Helper.Entites.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.DataAccess.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HelperDbContext _helperDbContext;
        public CategoryRepository(HelperDbContext helperDbContext)
        {
            _helperDbContext = helperDbContext;
        }

        public  async Task CreateCategory(Category category)
        {
            await _helperDbContext.Categories.AddAsync(category);
            await _helperDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var deleteCategory = await GetCategorypById(id);
            _helperDbContext.Categories.Remove(deleteCategory);
            await _helperDbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _helperDbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategorypById(int id)
        {
            var category = await _helperDbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task UpdateCategory(Category category)
        {
            var updateCategory = await _helperDbContext.Categories.FindAsync(category.CategoryId);

            updateCategory.CategoryName = category.CategoryName;

            _helperDbContext.Categories.Update(updateCategory);
            await _helperDbContext.SaveChangesAsync();
           }
    }
}

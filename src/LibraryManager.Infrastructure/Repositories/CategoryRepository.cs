using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext dataBase) : ICategoryRepository
    {
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            dataBase.Categories.Add(category);
            await dataBase.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            int deletedRows = await dataBase.Categories.Where(tmp=> tmp.Id == id)
                .ExecuteDeleteAsync();
            return deletedRows > 0;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await dataBase.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await dataBase.Categories.FirstOrDefaultAsync(
                tmp => tmp.Id == id);
        }

        public async Task<Category?> UpdateCategoryAsync(Category category)
        {
            Category? matchingCategory =
                await dataBase.Categories.FirstOrDefaultAsync(
                    tmp => tmp.Id == category.Id);
            if(matchingCategory is null)
            {
                return null;
            }

            dataBase.Entry(matchingCategory).CurrentValues.SetValues(category);

            await dataBase.SaveChangesAsync();
            return matchingCategory;
                
        }
    }
}

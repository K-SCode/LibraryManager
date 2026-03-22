using LibraryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category?> UpdateCategoryAsync(Category book);
    }
}

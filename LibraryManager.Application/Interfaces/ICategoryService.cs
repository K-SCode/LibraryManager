using LibraryManager.Application.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponse> CreateCategoryAsync(
            CreateCategoryRequest categoryRequest);
        Task<CategoryResponse> UpdateCategoryAsync(
            UpdateCategoryRequest categoryRequest,
            Guid id);
        Task DeleteCategoryByIdAsync(Guid id);
        Task<CategoryResponse> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
    }
}

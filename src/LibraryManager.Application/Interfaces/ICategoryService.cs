using LibraryManager.Application.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CreateCategoryResponse> CreateCategoryAsync(
            CreateCategoryRequest categoryRequest);
        Task<UpdateCategoryResponse> UpdateCategoryAsync(
            UpdateCategoryRequest categoryRequest,
            Guid id);
        Task DeleteCategoryByIdAsync(Guid id);
        Task<CategoryResponse> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
    }
}

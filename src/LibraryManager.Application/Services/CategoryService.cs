using LibraryManager.Application.Dtos.Categories;
using LibraryManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest categoryRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> GetCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest categoryRequest, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

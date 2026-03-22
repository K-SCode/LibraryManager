using LibraryManager.Application.Dtos.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<CreateAuthorResponse> CreateAuthorAsync(
            CreateAuthorRequest authorRequest);
        Task DeleteAuthorAsync(Guid id);
        Task<AuthorResponse> GetDetailsAuthorByIdAsync(Guid id);
        Task<AuthorShortResponse> GetAuthorByIdAsync(Guid id);
        Task<UpdateAuthorResponse> UpdateAuthorByIdAsync(
            Guid id,
            UpdateAuthorRequest authorRequest);
        Task<IEnumerable<AuthorShortResponse>> GetAllAuthorsAsync();
    }
}

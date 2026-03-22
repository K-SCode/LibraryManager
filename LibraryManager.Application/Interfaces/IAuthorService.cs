using LibraryManager.Application.Dtos.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorShortResponse> CreateAuthorAsync(
            CreateAuthorRequest authorRequest);
        Task<AuthorShortResponse> DeleteAuthorAsync(Guid id);
        Task GetDetailsAuthorByIdAsync(Guid id);
        Task<AuthorShortResponse> GetAuthorByIdAsync(Guid id);
        Task<AuthorResponse> UpdateAuthorByIdAsync(
            Guid id,
            UpdateAuthorRequest authorRequest);
        Task<IEnumerable<AuthorShortResponse>> GetAllAuthorsAsync();
    }
}

using LibraryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author?> GetAuthorByIdAsync(Guid id);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<bool> DeleteAuthorAsync(Guid id);
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author?> UpdateAuthorAsync(Author author);
    }
}

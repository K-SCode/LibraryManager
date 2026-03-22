using LibraryManager.Application.Dtos.Authors;
using LibraryManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Services
{
    public class AuthorService : IAuthorService
    {
        public Task<AuthorShortResponse> CreateAuthorAsync(CreateAuthorRequest authorRequest)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorShortResponse> DeleteAuthorAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorShortResponse>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorShortResponse> GetAuthorByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorResponse> GetDetailsAuthorByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorResponse> UpdateAuthorByIdAsync(UpdateAuthorRequest authorRequest, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

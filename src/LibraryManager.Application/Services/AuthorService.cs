using LibraryManager.Application.Dtos.Authors;
using LibraryManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Services
{
    public class AuthorService : IAuthorService
    {
        public Task<CreateAuthorResponse> CreateAuthorAsync(CreateAuthorRequest authorRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthorAsync(Guid id)
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

        public Task<UpdateAuthorResponse> UpdateAuthorByIdAsync(Guid id, UpdateAuthorRequest authorRequest)
        {
            throw new NotImplementedException();
        }
    }
}

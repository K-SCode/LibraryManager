using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Services
{
    public class BookService : IBookService
    {
        public Task<BookResponse> CreateBookAsync(CreateBookRequest bookRequest)
        {
            throw new NotImplementedException();
        }

        public Task<BookShortResponse> DeleteBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookShortResponse>> GetBookByFiltersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookResponse> GetBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookResponse> UpdateBookAsync(UpdateBookRequest bookRequest, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

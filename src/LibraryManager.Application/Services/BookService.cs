using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.Dtos.Common;
using LibraryManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Services
{
    public class BookService : IBookService
    {
        public Task<CreateBookResponse> CreateBookAsync(CreateBookRequest bookRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookShortResponse>> GetBookByFiltersAsync(BooksQueryParametersRequest parameters)
        {
            throw new NotImplementedException();
        }

        public Task<BookResponse> GetBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateBookResponse> UpdateBookAsync(Guid id, UpdateBookRequest bookRequest)
        {
            throw new NotImplementedException();
        }
    }
}

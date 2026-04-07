using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.Interfaces;
using LibraryManager.Domain.Contracts;
using LibraryManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Services
{
    public class BookService(
        IUnitOfWork unitOfWork) : IBookService
    {
        public Task<Result<CreateBookResponse>> CreateBookAsync(CreateBookRequest bookRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<BookShortResponse>>> GetBooksByFiltersAsync(BookSearchCriteria parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Result<BookResponse>> GetBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UpdateBookResponse>> UpdateBookAsync(Guid id, UpdateBookRequest bookRequest)
        {
            throw new NotImplementedException();
        }
    }
}

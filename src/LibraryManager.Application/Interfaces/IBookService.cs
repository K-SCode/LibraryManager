using LibraryManager.Application.Dtos.Books;
using LibraryManager.Domain.Common;
using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IBookService
    {
        Task<Result<IEnumerable<BookShortResponse>>> GetBooksByFiltersAsync(
            BookSearchCriteria parameters);
        Task<Result<CreateBookResponse>> CreateBookAsync(
            CreateBookRequest bookRequest);
        Task<Result<UpdateBookResponse>> UpdateBookAsync(
            Guid id,
            UpdateBookRequest bookRequest);
        Task<Result<BookResponse>> GetBookByIdAsync(Guid id);
        Task<Result<bool>> DeleteBookAsync(Guid id);


    }
}

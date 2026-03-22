using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.Dtos.Common;
using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookShortResponse>> GetBookByFiltersAsync(
            BooksQueryParametersRequest parameters);
        Task<CreateBookResponse> CreateBookAsync(
            CreateBookRequest bookRequest);
        Task<UpdateBookResponse> UpdateBookAsync(
            Guid id,
            UpdateBookRequest bookRequest);
        Task<BookResponse> GetBookByIdAsync(Guid id);
        Task DeleteBookAsync(Guid id);

    }
}

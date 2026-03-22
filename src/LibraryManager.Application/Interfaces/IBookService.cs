using LibraryManager.Application.Dtos.Books;
using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookShortResponse>> GetBookByFiltersAsync(
            OrderOptions orderBy = OrderOptions.ASC,
            string sortBy = nameof(BookShortResponse.Title));
        Task<BookResponse> CreateBookAsync(
            CreateBookRequest bookRequest);
        Task<BookResponse> UpdateBookAsync(
            Guid id,
            UpdateBookRequest bookRequest);
        Task<BookResponse> GetBookByIdAsync(Guid id);
        Task DeleteBookAsync(Guid id);

    }
}

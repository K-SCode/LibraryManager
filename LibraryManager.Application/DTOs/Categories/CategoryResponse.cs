using LibraryManager.Application.Dtos.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Categories
{
    public record CategoryResponse(
        Guid Id,
        string Name,
        IEnumerable<BookShortResponse> Books
        );

}

using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Books
{
    public record BookResponse(
        Guid Id,
        string Title,
        string Author,
        string Isbn,
        string Description,
        BookStatus Status,
        DateTime? ReturnDate,
        DateTime PublishDate,
        string CategoryName
        );

}

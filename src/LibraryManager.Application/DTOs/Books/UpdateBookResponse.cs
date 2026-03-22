using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Books
{
    public record UpdateBookResponse(
        Guid Id,
        string Title,
        Guid AuthorId,
        string Isbn,
        string Description,
        BookStatus Status,
        DateTime PublishDate,
        Guid CategoryId,
        Guid? CurrentBorrowerId,
        DateTime? ReturnDate
      );
}

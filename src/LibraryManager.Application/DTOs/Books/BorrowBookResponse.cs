using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Books
{
    public record BorrowBookResponse(
        Guid Id,
        string Status,
        string Isbn,
        string Title,
        Guid CurrentBorrowerId,
        DateTime? ReturnDate);
}

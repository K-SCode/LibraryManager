using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Books
{
    public record BorrowBookRequest(
        string Status,
        Guid CurrentBorrowerId,
        DateTime? ReturnDate
    );
}

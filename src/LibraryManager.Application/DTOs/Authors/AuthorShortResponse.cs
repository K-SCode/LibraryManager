using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Authors
{
    public record AuthorShortResponse(
        Guid Id,
        string FirstName,
        string LastName,
        int BooksCount
    );
}

using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Books
{
    public record BookShortResponse(
        Guid Id,
        string Title,
        Guid AuthorId,
        BookStatus Status,
        DateTime PublishDate,
        Guid CategoryId
        );

}

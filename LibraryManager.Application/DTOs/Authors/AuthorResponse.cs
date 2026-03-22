using LibraryManager.Application.Dtos.Books;

namespace LibraryManager.Application.Dtos.Authors
{
    public record AuthorResponse(
        Guid Id,
        string FirstName,
        string LastName,
        IEnumerable<BookShortResponse> Books
        );
}

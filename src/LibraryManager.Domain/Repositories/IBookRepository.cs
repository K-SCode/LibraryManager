using LibraryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<bool> DeleteBookAsync(Guid id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book?> UpdateBookAsync(Book book);
    }
}

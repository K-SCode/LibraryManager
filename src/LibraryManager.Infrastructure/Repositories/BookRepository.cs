using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public class BookRepository(ApplicationDbContext database) : IBookRepository
    {
        public async Task<Book> CreateBookAsync(Book book)
        {
            database.Books.Add(book);
            await database.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            int deletedRows = await database.Books.Where(tmp => tmp.Id == id)
                .ExecuteDeleteAsync();
            return deletedRows > 0;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            IEnumerable<Book> books = await database.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            return await database.Books.FirstOrDefaultAsync(
                tmp => tmp.Id == id);
        }

        public async Task<Book?> UpdateBookAsync(Book book)
        {
            Book? matchingBook = await database.Books.FirstOrDefaultAsync(
                tmp => tmp.Id == book.Id);
            if (matchingBook is null)
            {
                return null;
            }

            database.Entry(matchingBook).CurrentValues.SetValues(book);

            await database.Entry(matchingBook).Reference(tmp => tmp.Author).LoadAsync();
            await database.Entry(matchingBook).Reference(tmp => tmp.Category).LoadAsync();

            await database.SaveChangesAsync();
            return matchingBook;
        }
    }
}

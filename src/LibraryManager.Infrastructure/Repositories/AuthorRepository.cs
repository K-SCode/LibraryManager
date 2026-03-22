using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public class AuthorRepository(ApplicationDbContext database) 
        : IAuthorRepository
    {
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            database.Authors.Add(author);
            await database.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAuthorAsync(Guid id)
        {
            int deletedRows = await database.Authors.Where(tmp => tmp.Id == id)
                .ExecuteDeleteAsync();
            return deletedRows > 0;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await database.Authors.ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(Guid id)
        {
            return await database.Authors.FirstOrDefaultAsync(tmp => tmp.Id == id);
        }

        public async Task<Author?> UpdateAuthorAsync(Author author)
        {
            Author? matchingAuthor = await database.Authors.FirstOrDefaultAsync(
                tmp => tmp.Id == author.Id);
            if (matchingAuthor is null)
            {
                return null;
            }

            database.Entry(matchingAuthor).CurrentValues.SetValues(author);
            
            await database.SaveChangesAsync();
            return matchingAuthor;
        }
    }
}

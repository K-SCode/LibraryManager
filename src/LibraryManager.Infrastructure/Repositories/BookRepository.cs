using LibraryManager.Application.Specyfication;
using LibraryManager.Domain.Common;
using LibraryManager.Domain.Contracts;
using LibraryManager.Domain.Entities;
using LibraryManager.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LibraryManager.Infrastructure.Repositories
{
    public class BookRepository(ApplicationDbContext context) 
        : BaseRepository<Book>(context), IBookRepository
    {
        public async Task<bool> CheckIsbnExistsAsync(string isbn)
        {
            return await Context.Set<Book>().AnyAsync(book => book.Isbn == isbn);
        }
    }
}

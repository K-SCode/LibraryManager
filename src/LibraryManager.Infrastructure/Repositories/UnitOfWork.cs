using LibraryManager.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;
        private IBookRepository? _bookRepository;
        private IAuthorRepository? _authorRepository;
        private ICategoryRepository? _categoryRepository;

        public IBookRepository Book
        {
            get
            {
                _bookRepository ??= new BookRepository(_context);
                return _bookRepository;
            }
        }

        public IAuthorRepository Author
        {
            get
            {
                _authorRepository ??= new AuthorRepository(_context);
                return _authorRepository;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                _categoryRepository ??= new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        Task IUnitOfWork.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

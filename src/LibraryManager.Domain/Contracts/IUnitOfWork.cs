using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Contracts
{
    public interface IUnitOfWork
    {
        public IBookRepository Book { get; }
        public ICategoryRepository Category { get; }
        public IAuthorRepository Author { get; }
        Task SaveChangesAsync();
    }
}

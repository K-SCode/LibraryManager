using LibraryManager.Domain.Common;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Contracts
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<bool> CheckIsbnExistsAsync(string isbn);
    }
}

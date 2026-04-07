using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public class AuthorRepository(ApplicationDbContext context) 
        : BaseRepository<Author>(context), IAuthorRepository
    {
       
    }
}

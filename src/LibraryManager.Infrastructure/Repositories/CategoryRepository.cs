using LibraryManager.Domain.Contracts;
using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) 
        : BaseRepository<Category>(context), ICategoryRepository
    {
   
    }
}

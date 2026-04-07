using LibraryManager.Domain.Common;
using LibraryManager.Domain.Contracts;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enum;
using LibraryManager.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public abstract class BaseRepository<T>(ApplicationDbContext context)
        : IBaseRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext Context { get; set; } = context;


        public async Task<IReadOnlyList<T>> FindAllByCriteriaAsync(
            ISpecification<T> spec)
        {
            var items = Context.Set<T>()
                .AsQueryable()
                .ApplySpecification(spec)
                .AsNoTracking();

            return await items.ToListAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task AddAsync(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public async Task UpdateAsync(T entity)
        {

            Context.Set<T>().Update(entity);
        }

        public async Task<T?> FindByIdAsync(Guid id)
        {
            return await Context.Set<T>().Where(tmp => tmp.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}

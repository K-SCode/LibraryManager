using LibraryManager.Domain.Common;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LibraryManager.Domain.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> FindByIdAsync(Guid id);
        Task DeleteAsync(T entity);
        Task AddAsync(T entity);
        Task<IReadOnlyList<T>> FindAllByCriteriaAsync(ISpecification<T> spec);
   
        Task UpdateAsync(T entity);
    }
}

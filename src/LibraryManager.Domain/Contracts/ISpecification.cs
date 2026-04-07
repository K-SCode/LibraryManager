using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LibraryManager.Domain.Contracts
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>>? Criteria { get; }
        List<Expression<Func<T,object>>>? Include { get; }
        Expression<Func<T,object>>? OrderBy { get; }
        bool IsDescending { get; }
        int Skip { get; }
        int Take { get; }
    }
}

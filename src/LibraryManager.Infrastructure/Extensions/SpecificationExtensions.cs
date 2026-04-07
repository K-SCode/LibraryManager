using LibraryManager.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Extensions
{
    internal static class SpecificationExtensions
    {
        public static IQueryable<T> ApplySpecification<T>(
            this IQueryable<T> query, ISpecification<T> spec) 
            where T : class
        {
            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.Include is not null)
            {
                foreach (var item in spec.Include)
                {
                    query = query.Include(item);
                }
            }
            
            if(spec.OrderBy is not null)
            {
                query = spec.IsDescending ? 
                    query.OrderByDescending(spec.OrderBy) :
                    query.OrderBy(spec.OrderBy);
            }
            
            query = query.Skip(spec.Skip);
            query = query.Take(spec.Take);

            return query;
        }
    }
}

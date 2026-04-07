using LibraryManager.Domain.Common;
using LibraryManager.Domain.Contracts;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

namespace LibraryManager.Application.Specyfication
{
    public class BookSearchSpecification : ISpecification<Book>
    {
        public Expression<Func<Book, bool>>? Criteria { get; private set; }

        public List<Expression<Func<Book, object>>>? Include { get; private set; } = new();

        public Expression<Func<Book, object>>? OrderBy { get; private set; }

        public bool IsDescending { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public BookSearchSpecification(BookSearchCriteria criteria)
        {
            Include.Add(b => b.Author!);
            Include.Add(b => b.Category!);

            SetCriteria(criteria.SearchTerm,criteria.SearchBy);

            SetOrderExpression(criteria.SortBy,criteria.Order);

            Skip = (criteria.PageNumber - 1) * criteria.PageSize;
            Take = criteria.PageSize;
        }

        private void SetOrderExpression(string? sortBy, OrderOptions order)
        {
            Expression<Func<Book, object>>? orderExpression =
                sortBy switch
                {
                    nameof(Book.Title) => b => b.Title,
                    nameof(Book.Author) => b => b.Author!.LastName,
                    nameof(Book.Category) => b => b.Category!.Name,
                    nameof(Book.Status) => b => b.Status.ToString(),
                    nameof(Book.Isbn) => b => b.Isbn,
                    _ => b => b.Title
                };
            if (orderExpression is not null)
            {
                OrderBy = orderExpression;
                IsDescending = order == OrderOptions.ASC ? false : true;
            }
            else
            {
                OrderBy = b => b.Title;
                IsDescending = true;
            }
        }

        private void SetCriteria(string? searchTerm, string? searchBy)
        {
            if (!string.IsNullOrEmpty(searchBy) &&
                !string.IsNullOrEmpty(searchTerm))
            {
                Criteria = (searchBy, searchTerm) switch
                {
                    (nameof(Book.Title), _) => b => b.Title.Contains(searchTerm),
                    (nameof(Book.Author), _) => b => b.Author!.FirstName.Contains(searchTerm) ||
                        b.Author.LastName.Contains(searchTerm),
                    (nameof(Book.Category), _) => b => b.Category!.Name.Contains(searchTerm),
                    (nameof(Book.Isbn), _) => b => b.Isbn.Contains(searchTerm),
                    _ => b => b.Title.Contains(searchTerm)
                };
            }
        }
    }
}

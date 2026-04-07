using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Common
{
    public record PagedResponse<T>(
        IEnumerable<T> Items,
        int TotalCount,
        int PageNumber,
        int PageSize
    )
    {
        public int TotalPages => 
            (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
    }
}

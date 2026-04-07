using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Common
{
    public record BookSearchCriteria(
        string? SearchBy = null,
        string? SearchTerm = null,
        int PageNumber = 1,
        int PageSize = 10,
        string? SortBy = null,
        OrderOptions Order = OrderOptions.ASC
    );

}

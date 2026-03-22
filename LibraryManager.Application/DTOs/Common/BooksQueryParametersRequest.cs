using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Common
{
    public record BooksQueryParametersRequest(
        string? SearchTerm = null,
        int PageNumber = 1,
        int PageSize = 10,
        string? SortBy = null,
        OrderOptions Order = OrderOptions.ASC
    );

}

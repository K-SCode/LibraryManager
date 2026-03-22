using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Categories
{
    public record CreateCategoryResponse(
        Guid Id,
        string Name
    );
}

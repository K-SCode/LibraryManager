using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Authors
{
    public record CreateAuthorResponse(
        Guid Id,
        string FirstName,
        string LastName
    );
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Authors
{
    public record CreateAuthorRequest(
        string FirstName,
        string LastName
    );
}

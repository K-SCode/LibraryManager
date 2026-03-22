using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Dtos.Authors
{
    public record UpdateAuthorRequest(
        string FirstName,
        string LastName
    );
}

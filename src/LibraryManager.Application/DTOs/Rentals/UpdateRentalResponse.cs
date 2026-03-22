using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.DTOs.Rentals
{
    public record UpdateRentalResponse(
        Guid Id,
        DateTime ActualReturnDate,
        bool IsOverdue
    );
}

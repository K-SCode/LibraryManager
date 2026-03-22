using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.DTOs.Rentals
{
    public record UpdateRentalRequest(
        DateTime ActualReturnDate,
        bool IsOverdue
    );
}

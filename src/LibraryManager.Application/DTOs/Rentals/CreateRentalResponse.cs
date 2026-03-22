using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.DTOs.Rentals
{
    public record CreateRentalResponse(
        Guid Id,
        Guid BookId,
        DateTime DueDate,
        DateTime RentalDate,
        DateTime ActualReturnDate,
        bool IsOverdue
        );
}

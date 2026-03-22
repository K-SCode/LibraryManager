using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.DTOs.Rentals
{
    public record CreateRentalRequest(
        Guid BookId,
        DateTime DueDate,
        DateTime RentalDate
    );
}

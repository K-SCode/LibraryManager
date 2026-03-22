using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.DTOs.Rentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IRentalService
    {
        Task<CreateRentalResponse> RentBookAsync(
            Guid id,
            CreateRentalRequest bookRequest);
        Task<CreateRentalResponse> ReturnBookAsync(Guid Id);
        Task<IEnumerable<BookShortResponse>> GetAllRentalsBookAsync();
        //IEnumerable<BookShortResponse> GetUserRentalHistory();
        Task<IEnumerable<CreateRentalResponse>> GetOverdueRentalsAsync();
        Task<CreateRentalResponse> GetRentalBookByIdAsync(Guid id);
    }
}

using LibraryManager.Application.Dtos.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IRentalService
    {
        Task<BorrowBookResponse> RentBookAsync(
            Guid id,
            BorrowBookRequest bookRequest);
        Task<BorrowBookResponse> ReturnBookAsync(Guid Id);
        Task<IEnumerable<BookShortResponse>> GetAllRentalsBookAsync();
        //IEnumerable<BookShortResponse> GetUserRentalHistory();
        Task<IEnumerable<BorrowBookResponse>> GetOverdueRentalsAsync();
        Task<BorrowBookResponse> GetRentalBookByIdAsync(Guid id);
    }
}

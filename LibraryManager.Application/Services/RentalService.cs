using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Services
{
    public class RentalService : IRentalService
    {
        public Task<IEnumerable<BookShortResponse>> GetAllRentalsBookAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BorrowBookResponse>> GetOverdueRentalsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BorrowBookResponse> GetRentalBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BorrowBookResponse> RentBookAsync(BorrowBookRequest bookRequest, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BorrowBookResponse> ReturnBookAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

using LibraryManager.Application.Dtos.Books;
using LibraryManager.Application.DTOs.Rentals;
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

        public Task<IEnumerable<CreateRentalResponse>> GetOverdueRentalsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CreateRentalResponse> GetRentalBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CreateRentalResponse> RentBookAsync(Guid id, CreateRentalRequest bookRequest)
        {
            throw new NotImplementedException();
        }

        public Task<CreateRentalResponse> ReturnBookAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

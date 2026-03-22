using LibraryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Repositories
{
    public interface IRentalRepository
    {
        Task<Rental?> GetRentalByIdAsync(Guid id);
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<bool> DeleteRentalAsync(Guid id);
        Task<Rental> CreateRentalAsync(Rental rental);
        Task<Rental?> UpdateRentalAsync(Rental rental);
    }
}

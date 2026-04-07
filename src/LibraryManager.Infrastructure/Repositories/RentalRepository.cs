using LibraryManager.Domain.Contracts;
using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Repositories
{
    public class RentalRepository(ApplicationDbContext database)
        : IRentalRepository
    {
        public async Task<Rental> CreateRentalAsync(Rental retnal)
        {
            database.Rentals.Add(retnal);
            await database.SaveChangesAsync();
            return retnal;
        }

        public async Task<bool> DeleteRentalAsync(Guid id)
        {
            int deletedRows = 
                await database.Rentals.Where(tmp => tmp.Id == id)
                .ExecuteDeleteAsync();

            return deletedRows > 0;
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await database.Rentals.ToListAsync();
        }

        public async Task<Rental?> GetRentalByIdAsync(Guid id)
        {
           return await database.Rentals.FirstOrDefaultAsync(
               tmp => tmp.Id == id);
        }

        public async Task<Rental?> UpdateRentalAsync(Rental retnal)
        {
            Rental? matchingPerson = 
                await database.Rentals.FirstOrDefaultAsync(
                    tmp=> tmp.Id == retnal.Id);
            if(matchingPerson is null)
            {
                return null;
            }

            database.Entry(matchingPerson).CurrentValues.SetValues(retnal);

            await database.SaveChangesAsync();
            return retnal;
        }
    }
}

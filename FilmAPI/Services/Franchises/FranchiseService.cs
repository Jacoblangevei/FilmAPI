using FilmAPI.Data;
using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAPI.Services.Franchises
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieDbContext _context;

        public FranchiseService(MovieDbContext context)
        {
            _context = context;
        }

        // Get all Franchises
        public async Task<IEnumerable<Franchise>> GetFranchisesAsync()
        {
            return await _context.Franchises.ToListAsync();
        }

        // Get Franchise by Id
        public async Task<Franchise> GetFranchiseByIdAsync(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }

        // Add Franchise
        public async Task AddFranchiseAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
        }

        // Update Franchise
        public async Task UpdateFranchiseAsync(Franchise franchise)
        {
            _context.Franchises.Update(franchise);
            await _context.SaveChangesAsync();
        }

        // Delete Franchise
        public async Task DeleteFranchiseAsync(int id)
        {
            var franchiseToDelete = await _context.Franchises.FindAsync(id);
            if (franchiseToDelete != null)
            {
                _context.Franchises.Remove(franchiseToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

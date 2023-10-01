using FilmAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmAPI.Services.Franchises
{
    public interface IFranchiseService
    {
        /// <summary>
        /// Retrieves all franchises from the database.
        /// </summary>
        /// <returns>A list of all franchises.</returns>
        Task<IEnumerable<Franchise>> GetFranchisesAsync();

        /// <summary>
        /// Retrieves a franchise from the database based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the franchise.</param>
        /// <returns>The franchise with the specified identifier, or null if it doesn't exist.</returns>
        Task<Franchise> GetFranchiseByIdAsync(int id);

        /// <summary>
        /// Adds a new franchise to the database.
        /// </summary>
        /// <param name="franchise">The franchise entity to add.</param>
        /// <returns>A task representing the asynchronous add operation.</returns>
        Task AddFranchiseAsync(Franchise franchise);

        /// <summary>
        /// Updates the details of an existing franchise in the database.
        /// </summary>
        /// <param name="franchise">The franchise entity with updated details.</param>
        /// <returns>A task representing the asynchronous update operation.</returns>
        Task UpdateFranchiseAsync(Franchise franchise);

        /// <summary>
        /// Deletes a franchise from the database based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the franchise to delete.</param>
        /// <returns>A task representing the asynchronous delete operation.</returns>
        Task DeleteFranchiseAsync(int id);
    }
}


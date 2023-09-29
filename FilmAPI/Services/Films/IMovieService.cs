using FilmAPI.Services;
using FilmAPI.Data.Models;
using FilmAPI.Data.Exceptions;

namespace FilmAPI.Services.Films
{
    // Interface for MovieService
    public interface IMovieService : ICrudService<Movie, int>
    {   
        // Returns collection of movies and movie by ID.
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);   
    }
}
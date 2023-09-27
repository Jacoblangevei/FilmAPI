using FilmAPI.Services;
using FilmAPI.Data.Models;
using FilmAPI.Data.Exceptions;

namespace FilmAPI.Services.Films
{
    public interface IMovieService : ICrudService<Movie, int>
    {
        
            Task<IEnumerable<Movie>> GetMoviesAsync();
            Task<Movie> GetMovieByIdAsync(int id);
            Task AddMovieAsync(Movie movie);
            Task UpdateMovieAsync(Movie movie);
            Task DeleteMovieAsync(int id);
        

    }
}


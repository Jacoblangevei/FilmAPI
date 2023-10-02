/*using FilmAPI.Data;
using FilmAPI.Data.Models;
using FilmAPI.Controllers;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.Films
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}*/

using System.Collections.Generic;
using System.Threading.Tasks;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.Films
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        // Get all Movies
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        // Get Movie by Id
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        // Add Movie
        public async Task AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        // Update Movie
        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        // Delete Movie
        public async Task DeleteMovieAsync(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}


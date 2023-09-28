using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmAPI.Controllers
{
    /// <summary>
    /// Controller for managing movies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of all movies.
        /// </summary>
        /// <returns>A list of movies.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            return await _context.Movies.ToListAsync();
        }

        /// <summary>
        /// Get a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        /// <summary>
        /// Update a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The updated movie data.</param>
        /// <returns>NoContent if the movie is updated successfully.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new movie.
        /// </summary>
        /// <param name="movie">The movie data to create.</param>
        /// <returns>A newly created movie.</returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'MovieDbContext.Movies' is null.");
            }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Delete a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>NoContent if the movie is deleted successfully.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

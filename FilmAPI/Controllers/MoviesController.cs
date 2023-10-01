/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using AutoMapper;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Services.Films;

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var movies = await _movieService.GetMoviesAsync();
            if (movies == null || !movies.Any())
            {
                return NotFound();
            }
            return _mapper.Map<List<MovieDTO>>(movies);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieDTO>(movie);
        }


        // PUT: api/Movies/5
        // Denne må gjøres om
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieDTO(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            await _movieService.UpdateMovieAsync(movie);
            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<MovieDTO>> PostMovie(MoviePostDTO moviePostDTO)
        {
            var movie = _mapper.Map<Movie>(moviePostDTO);

            await _movieService.AddMovieAsync(movie);

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return CreatedAtAction("GetMovie", new { id = movieDTO.Id }, movieDTO);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }

        private async Task<bool> MovieExistsAsync(int id)
        {

            var movie = await _movieService.GetMovieByIdAsync(id);
            return movie != null;
        }
    }
}*/

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmAPI.Data.Models;
using AutoMapper;
using FilmAPI.Data.DTOs.Movies;
using FilmAPI.Services.Films;

namespace FilmAPI.Controllers
{
    /// <summary>
    /// Provides endpoints to manage movies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="movieService">The movie service.</param>
        /// <param name="mapper">The mapper service.</param>
        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        /// <returns>A list of movies in the database.</returns>
        /// <response code="200">Returns the list of movies.</response>
        /// <response code="404">If no movies are found.</response>

        // GET: api/Movies
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            var movies = await _movieService.GetMoviesAsync();
            if (movies == null || !movies.Any())
            {
                return NotFound();
            }
            return _mapper.Map<List<MovieDTO>>(movies);
        }

        /// <summary>
        /// Retrieves a specific movie by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the movie.</param>
        /// <returns>The movie with the specified identifier.</returns>
        // GET: api/Movies/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieDTO>(movie);
        }

        /// <summary>
        /// Updates a specific movie's details.
        /// </summary>
        /// <param name="id">The unique identifier of the movie.</param>
        /// <param name="movieUpdateDTO">The updated details of the movie.</param>
        // PUT: api/Movies/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutMovieDTO(int id, [FromBody] MoviePutDTO movieUpdateDTO)
        {
            var movie = _mapper.Map<Movie>(movieUpdateDTO);
            if (id != movie.Id)
            {
                return BadRequest();
            }
            await _movieService.UpdateMovieAsync(movie);
            return NoContent();
        }

        /// <summary>
        /// Creates a new movie.
        /// </summary>
        /// <param name="moviePostDTO">The details of the new movie.</param>
        /// <returns>The created movie.</returns>
        // POST: api/Movies
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MovieDTO>> PostMovie(MoviePostDTO moviePostDTO)
        {
            var movie = _mapper.Map<Movie>(moviePostDTO);

            await _movieService.AddMovieAsync(movie);

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return CreatedAtAction("GetMovie", new { id = movieDTO.Id }, movieDTO);
        }

        /// <summary>
        /// Deletes a specific movie by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the movie to delete.</param>
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Checks if a movie with the specified identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the movie.</param>
        /// <returns>True if the movie exists, otherwise false.</returns>
        private async Task<bool> MovieExistsAsync(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            return movie != null;
        }
    }
}
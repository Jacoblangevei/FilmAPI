using Microsoft.AspNetCore.Mvc;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Movie movie)
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
}
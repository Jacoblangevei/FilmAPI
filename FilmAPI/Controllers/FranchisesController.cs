/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using AutoMapper;
using FilmAPI.Data.DTOs.Franchises; // Import your Franchise DTOs

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper; // Inject IMapper

        public FranchisesController(MovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; // Initialize IMapper
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises()
        {
            if (_context.Franchises == null)
            {
                return NotFound();
            }
            var franchises = await _context.Franchises.ToListAsync();
            var franchiseDTOs = _mapper.Map<List<FranchiseDTO>>(franchises); // Map to DTOs
            return franchiseDTOs;
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            if (_context.Franchises == null)
            {
                return NotFound();
            }
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            var franchiseDTO = _mapper.Map<FranchiseDTO>(franchise); // Map to DTO
            return franchiseDTO;
        }

        // PUT: api/Franchises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO franchisePutDTO)
        {
            if (id != franchisePutDTO.Id)
            {
                return BadRequest();
            }

            var franchise = _mapper.Map<Franchise>(franchisePutDTO); // Map from DTO to entity

            _context.Entry(franchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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

        // POST: api/Franchises
        [HttpPost]
        public async Task<ActionResult<FranchiseDTO>> PostFranchise(FranchisePostDTO franchisePostDTO)
        {
            if (_context.Franchises == null)
            {
                return Problem("Entity set 'MovieDbContext.Franchises'  is null.");
            }

            var franchise = _mapper.Map<Franchise>(franchisePostDTO); // Map from DTO to entity

            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            var franchiseDTO = _mapper.Map<FranchiseDTO>(franchise); // Map to DTO

            return CreatedAtAction("GetFranchise", new { id = franchiseDTO.Id }, franchiseDTO);
        }

        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (_context.Franchises == null)
            {
                return NotFound();
            }
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FranchiseExists(int id)
        {
            return (_context.Franchises?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}*/

using FilmAPI.Services.Franchises;
using FilmAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FilmAPI.Data.DTOs.Franchises;
using AutoMapper;

namespace FilmAPI.Controllers
{
    /// <summary>
    /// Provides endpoints to manage franchises.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FranchisesController"/> class.
        /// </summary>
        /// <param name="franchiseService">The franchise service.</param>
        /// <param name="mapper">The mapper service.</param>
        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all franchises.
        /// </summary>
        /// <returns>A list of franchises in the database.</returns>
        /// <response code="200">Returns the list of franchises.</response>
        /// <response code="404">If no franchises are found.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises()
        {
            var franchises = await _franchiseService.GetFranchisesAsync();
            if (franchises == null || !franchises.Any())
            {
                return NotFound();
            }
            return _mapper.Map<List<FranchiseDTO>>(franchises);
        }

        /// <summary>
        /// Retrieves a specific franchise by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the franchise.</param>
        /// <returns>The franchise with the specified identifier.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id)
        {
            var franchise = await _franchiseService.GetFranchiseByIdAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<FranchiseDTO>(franchise);
        }

        // Other methods for PUT, POST, DELETE, etc., can be added similar to the MoviesController. 

        // ... Add PUT, POST, DELETE methods here ...

        /// <summary>
        /// Checks if a franchise with the specified identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the franchise.</param>
        /// <returns>True if the franchise exists, otherwise false.</returns>
        private async Task<bool> FranchiseExistsAsync(int id)
        {
            var franchise = await _franchiseService.GetFranchiseByIdAsync(id);
            return franchise != null;
        }
    }
}

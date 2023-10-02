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

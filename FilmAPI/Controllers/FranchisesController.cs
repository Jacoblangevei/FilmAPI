using Microsoft.AspNetCore.Mvc;
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
}
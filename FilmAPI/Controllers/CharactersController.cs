/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using AutoMapper;

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public CharactersController(MovieDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
          if (_context.Characters == null)
          {
              return NotFound();
          }
            return await _context.Characters.ToListAsync();
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
          if (_context.Characters == null)
          {
              return NotFound();
          }
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
          if (_context.Characters == null)
          {
              return Problem("Entity set 'MovieDbContext.Characters'  is null.");
          }
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilmAPI.Data.Models;
using FilmAPI.Services.Characters;
using AutoMapper;
using FilmAPI.Data.DTOs.Characters;

namespace FilmAPI.Controllers
{
    /// <summary>
    /// Provides APIs for performing operations related to Characters.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharactersController"/> class.
        /// </summary>
        /// <param name="characterService">The character service.</param>
        /// <param name="mapper">The mapper.</param>
        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of all characters.
        /// </summary>
        /// <returns>A list of characters.</returns>
        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            var characters = await _characterService.GetCharactersAsync();
            if (characters == null || !characters.Any())
            {
                return NotFound();
            }

            return _mapper.Map<List<CharacterDTO>>(characters);
        }

        /// <summary>
        /// Gets the character with the specified ID.
        /// </summary>
        /// <param name="id">The character's ID.</param>
        /// <returns>The character with the given ID or NotFound if it doesn't exist.</returns>
        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return _mapper.Map<CharacterDTO>(character);
        }

        /// <summary>
        /// Updates the character with the specified ID.
        /// </summary>
        /// <param name="id">The character's ID.</param>
        /// <param name="characterDTO">The character data for updating.</param>
        /// <returns>NoContent if the operation was successful, BadRequest if IDs mismatch, or NotFound if the character doesn't exist.</returns>
        // PUT: api/Characters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDTO characterDTO)
        {
            if (id != characterDTO.Id)
            {
                return BadRequest();
            }

            var character = _mapper.Map<Character>(characterDTO);
            await _characterService.UpdateCharacterAsync(character);

            return NoContent();
        }

        /// <summary>
        /// Adds a new character to the database.
        /// </summary>
        /// <param name="characterPostDTO">The character data for creation.</param>
        /// <returns>The created character's details.</returns>
        // POST: api/Characters
        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> PostCharacter(CharacterPostDTO characterPostDTO)
        {
            var character = _mapper.Map<Character>(characterPostDTO);

            await _characterService.AddCharacterAsync(character);

            var characterDTO = _mapper.Map<CharacterDTO>(character);

            return CreatedAtAction("GetCharacter", new { id = characterDTO.Id }, characterDTO);
        }

        /// <summary>
        /// Deletes the character with the specified ID.
        /// </summary>
        /// <param name="id">The character's ID.</param>
        /// <returns>NoContent if the operation was successful or NotFound if the character doesn't exist.</returns>
        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            await _characterService.DeleteCharacterAsync(id);

            return NoContent();
        }
    }
}
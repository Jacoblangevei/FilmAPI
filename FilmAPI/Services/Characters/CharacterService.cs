using FilmAPI.Data.Models;
using FilmAPI.Data;
using FilmAPI.Services.Characters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class CharacterService : ICharacterService
{
    private readonly MovieDbContext _context;

    public CharacterService(MovieDbContext context)
    {
        _context = context;
    }

    // Get all Characters
    public async Task<IEnumerable<Character>> GetCharactersAsync()
    {
        return await _context.Characters.ToListAsync();
    }

    // Get Character by Id
    public async Task<Character> GetCharacterByIdAsync(int id)
    {
        return await _context.Characters.FindAsync(id);
    }

    // Create Character
    public async Task AddCharacterAsync(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    // Update Character
    public async Task UpdateCharacterAsync(Character character)
    {
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
    }

    // Delete Character
    public async Task DeleteCharacterAsync(int id)
    {
        var characterToDelete = await _context.Characters.FindAsync(id);
        if (characterToDelete != null)
        {
            _context.Characters.Remove(characterToDelete);
            await _context.SaveChangesAsync();
        }
    }
}

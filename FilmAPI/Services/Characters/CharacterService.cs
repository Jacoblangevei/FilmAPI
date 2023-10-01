using FilmAPI.Data.Models;
using FilmAPI.Data;
using FilmAPI.Services.Characters;
using Microsoft.EntityFrameworkCore;

public class CharacterService : ICharacterService
{
    private readonly MovieDbContext _context;

    public CharacterService(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Character>> GetCharactersAsync()
    {
        return await _context.Characters.ToListAsync();
    }

    public async Task<Character> GetCharacterByIdAsync(int id)
    {
        return await _context.Characters.FindAsync(id);
    }

    public async Task CreateAsync(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Character character)
    {
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var characterToDelete = await _context.Characters.FindAsync(id);
        if (characterToDelete != null)
        {
            _context.Characters.Remove(characterToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public Task AddCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCharacterAsync(int id)
    {
        throw new NotImplementedException();
    }
}


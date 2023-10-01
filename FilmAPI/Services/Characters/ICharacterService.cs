using FilmAPI.Data.Models;

namespace FilmAPI.Services.Characters
{
    public interface ICharacterService : ICrudService<Character, int>
    {
        Task<IEnumerable<Character>> GetCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int id);
        Task AddCharacterAsync(Character character);
        Task UpdateCharacterAsync(Character character);
        Task DeleteCharacterAsync(int id);
    }
}

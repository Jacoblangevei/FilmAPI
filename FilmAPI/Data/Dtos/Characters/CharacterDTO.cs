using FilmAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.Dtos.Characters
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }

        // Navigation property
        public ICollection<Character> Characters { get; set; }
    }
}

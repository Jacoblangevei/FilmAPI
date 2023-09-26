using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }

        // Navigation property
        public ICollection<MovieCharacter> MovieCharacters { get; set; }
    }
}

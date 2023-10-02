namespace FilmAPI.Data.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; } // Nullable because not all characters may have an alias.
        public string Gender { get; set; } 
        public string PictureUrl { get; set; } // URL to the character's photo.
        // Navigation properties
        public virtual ICollection<Movie> Movies { get; set; } // A character can be in multiple movies.
    }
}
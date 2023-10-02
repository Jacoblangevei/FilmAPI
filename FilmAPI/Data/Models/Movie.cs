namespace FilmAPI.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; } // Comma-separated genres.
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureUrl { get; set; } // URL to the movie poster.
        public string TrailerUrl { get; set; } // YouTube link.
        // Navigation properties
        public int FranchiseId { get; set; } // Foreign key.
        public virtual Franchise Franchise { get; set; }
        public virtual ICollection<Character> Characters { get; set; } // A movie has multiple characters.
    }
}
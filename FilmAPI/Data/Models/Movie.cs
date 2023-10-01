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


/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmAPI.Data.Models
{
    public class Movie
    { 
        [Key]
        public int Id { get; set; }

        //[Required]
        //[StringLength(150)]
        public string? Title { get; set; }

        //[Required]
        //[StringLength(200)]
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? Director { get; set; }
        public string? PictureUrl { get; set; }
        public string? TrailerUrl { get; set; }

        // Navigation property
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }
    }
}*/
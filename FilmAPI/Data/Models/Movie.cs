using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmAPI.Data.Models
{
    public class Movie
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }

        // Navigation property
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
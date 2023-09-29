using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.DTOs.Movies
{
    public class MoviePostDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Range(1900, 2100)] // Just an example range for a valid movie release year
        public int ReleaseYear { get; set; }

        [Required]
        public string Director { get; set; }

        public string PictureUrl { get; set; }

        public string TrailerUrl { get; set; }

        //[Required]
        [DefaultValue(1)]
        public int FranchiseId { get; set; }
    }
}


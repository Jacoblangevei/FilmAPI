using FilmAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.DTOs.Movies
{
    public class MoviePutDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }

        [Range(1900, 2100)] // Example validation for years
        public int ReleaseYear { get; set; }

        public string Director { get; set; }

        public string PictureUrl { get; set; }

        public string TrailerUrl { get; set; }

        //public int FranchiseId { get; set; }
    }
}

using FilmAPI.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.DTOs.Movies
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }

        // Navigation property
        [DefaultValue(1)]
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
using FilmAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.Dtos.Franchises
{
    public class FranchiseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Movie> Movies { get; set; }
    }
}

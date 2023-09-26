using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.Entities
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Movie> Movies { get; set; }
    }
}

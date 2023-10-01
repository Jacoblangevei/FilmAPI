using System.ComponentModel.DataAnnotations;

/*namespace FilmAPI.Data.Models
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Navigation property
        public ICollection<Movie>? Movies { get; set; }
    }
}*/

namespace FilmAPI.Data.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Navigation properties
        public virtual ICollection<Movie> Movies { get; set; } // A franchise has multiple movies.
    }
}

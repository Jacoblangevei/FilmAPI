using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*namespace FilmAPI.Data.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        //[Required]
        [StringLength(10)]
        public string Gender { get; set; }

        //[Required]
        [StringLength(255)]
        public string PictureUrl { get; set; }

        // Navigation property
        public ICollection<Character> Characters { get; set; }
    }
}*/

namespace FilmAPI.Data.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; } // Nullable because not all characters may have an alias.
        public string Gender { get; set; } // Could be improved by using an Enum.
        public string PictureUrl { get; set; } // URL to the character's photo.
        // Navigation properties
        public virtual ICollection<Movie> Movies { get; set; } // A character can be in multiple movies.
    }
}
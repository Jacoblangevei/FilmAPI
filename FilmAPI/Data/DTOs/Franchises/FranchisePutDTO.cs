using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.DTOs.Franchises
{
    public class FranchisePutDTO
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

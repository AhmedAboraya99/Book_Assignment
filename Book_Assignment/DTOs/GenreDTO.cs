using System.ComponentModel.DataAnnotations;

namespace Book_Assignment.DTOs
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }

    }
}

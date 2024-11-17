using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Book_Assignment.DTOs
{
    public class BookDTO
    {
        [Required]
        public string Title { get; set; }

        public DateTime PublishedYear { get; set; }

        public List<int> AuthorIds { get; set; } = new List<int>();

        public List<int> GenreIds { get; set; } = new List<int>();

    }

    public class BookToReturnDTO
    {

        [Required]
        public string Title { get; set; }

        public DateTime PublishedYear { get; set; }

        public List<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();

        public List<GenreDTO> Genres { get; set; } = new List<GenreDTO>();

    }
}

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Assignment.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public DateTime PublishedYear { get; set; }

        
        public required ICollection<Author> Authors { get; set; }

        public ICollection<Genre>? Genres { get; set; }




    }
}

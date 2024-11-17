using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Assignment.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new Collection<Book>();
    }
}

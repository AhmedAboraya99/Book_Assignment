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

        
        public IList<Author>? Authors { get; set; }

        public IList<Genre>? Genres { get; set; }




    }
}

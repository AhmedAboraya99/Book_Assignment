using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Assignment.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Please Enter Phone Number")]
        public string? Phone { get; set; }
        [EmailAddress(ErrorMessage ="Please Enter Correct Email")]
        public string? Email { get; set; }

        public ICollection<Book> Books { get; set; } = new Collection<Book>();

        



    }
}

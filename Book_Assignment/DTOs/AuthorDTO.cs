using System.ComponentModel.DataAnnotations;

namespace Book_Assignment.DTOs
{
    public class AuthorDTO
    {
        [Required]
        public string Name { get; set; }
        [Phone(ErrorMessage = "Please Enter Phone Number")]
        public string? Phone { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Correct Email")]
        public string? Email { get; set; }
        public List<int>? BooksId { get; set; }
        public int? NationalityId { get; set; }


    }
    public class AuthorToReturnDTO
    {
        [Required]
        public string Name { get; set; }
        [Phone(ErrorMessage = "Please Enter Phone Number")]
        public string? Phone { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Correct Email")]
        public string? Email { get; set; }
        public List<BookDTO> Books { get; set; }
        public NationalityDTO? Nationality { get; set; }

    }
}

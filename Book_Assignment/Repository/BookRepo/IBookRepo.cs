using Book_Assignment.DTOs;
using Microsoft.Identity.Client;

namespace Book_Assignment.Repository.BookRepo
{
    public interface IBookRepo
    {
        public BookToReturnDTO GetById(int id);
        public List<BookToReturnDTO> GetAll();
        public BookDTO Add(BookDTO bookDTO);

        public BookDTO Update(int Id, BookDTO bookDTO);

        public BookDTO DeleteById(int id);
    }
}

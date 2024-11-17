using Book_Assignment.DTOs;

namespace Author_Assignment.Repository.AuthorRepo
{
    public interface IAuthorRepo
    {
        public AuthorDTO GetById(int id);
        public List<AuthorDTO> GetAll();

        public AuthorDTO Add(AuthorDTO bookDTO);

        public AuthorDTO Update(AuthorDTO bookDTO);

        public AuthorDTO DeleteById(int id);
    }
}

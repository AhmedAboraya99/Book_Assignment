using Book_Assignment.DTOs;

namespace Author_Assignment.Repository.AuthorRepo
{
    public interface IAuthorRepo
    {
        public AuthorDTO GetById(int id);
        public List<AuthorDTO> GetAll();

        public AuthorDTO Add(AuthorDTO bookDTO);

        public AuthorToReturnDTO AddDataToAuthor(AuthorToReturnDTO authorDTO);
        public AuthorDTO Update(int Id, AuthorDTO bookDTO);



        public AuthorDTO DeleteById(int id);
    }
}

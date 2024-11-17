using Book_Assignment.DTOs;

namespace Genre_Assignment.Repository.GenreRepo
{
    public interface IGenreRepo
    {
        public GenreDTO GetById(int id);
        public List<GenreDTO> GetAll();

        public GenreDTO Add(GenreDTO bookDTO);

        public GenreDTO Update(GenreDTO bookDTO);

        public GenreDTO DeleteById(int id);
    }
}

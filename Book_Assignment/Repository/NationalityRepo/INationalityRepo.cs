using Book_Assignment.DTOs;
using Book_Assignment.Models;

namespace Book_Assignment.Repository.NationalityRepo
{
    public interface INationalityRepo
    {
        public NationalityDTO GetById(int id);
        public List<NationalityDTO> GetAll();
        public NationalityDTO Add(NationalityDTO nationalityDTO);

        public NationalityDTO Update(NationalityDTO nationalityDTO);

        public NationalityDTO DeleteById(int id);
    }
}

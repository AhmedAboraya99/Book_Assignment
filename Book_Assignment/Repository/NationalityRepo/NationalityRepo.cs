using Book_Assignment.DTOs;
using Book_Assignment.Models;

namespace Book_Assignment.Repository.NationalityRepo
{
    public class NationalityRepo : INationalityRepo
    {
        private readonly AppDbContext _context;

        public NationalityRepo(AppDbContext context)
        {
            _context = context;
        }

        public NationalityDTO Add(NationalityDTO nationalityDTO)
        {
            var nationality = new Nationality
            {
                Name = nationalityDTO.Name,
                Authors = _context.authors
                .Where(a => nationalityDTO.AuthorsId.Contains(a.Id)).ToList(),

            };
           return nationalityDTO;
        }

        public NationalityDTO DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<NationalityDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public NationalityDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public NationalityDTO Update(NationalityDTO nationalityDTO)
        {
            throw new NotImplementedException();
        }
    }
}

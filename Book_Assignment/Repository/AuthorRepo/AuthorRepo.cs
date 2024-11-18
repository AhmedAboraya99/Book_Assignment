using Author_Assignment.Repository.AuthorRepo;
using Book_Assignment.DTOs;
using Book_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Assignment.Repository.AuthorRepo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;

        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }

        public AuthorDTO Add(AuthorDTO authorDTO)
        {
            // Select existing books from the database
            var books = _context.books
                .Where(b => authorDTO.BooksId != null && authorDTO.BooksId.Contains(b.Id))
                .ToList();

            // Create a new Author entity
            var author = new Author
            {
                Name = authorDTO.Name,
                Phone = authorDTO.Phone,
                Email = authorDTO.Email,
                NationalityId = authorDTO.NationalityId,
                Books = books // Link the selected books
            };

            // Add the author to the database
            _context.authors.Add(author);
            _context.SaveChanges();


            return authorDTO;
        }


        public AuthorToReturnDTO AddDataToAuthor(AuthorToReturnDTO authorDTO)
        {

            // Get all existing book titles and nationalities from the database
            var existingBookTitles = _context.books.Select(b => b.Title).ToList();

            // Check if the nationality already exists
            Nationality nationality = _context.nationality
                .FirstOrDefault(n => n.Name == authorDTO.Nationality.Name);

            if (nationality == null)
            {
                nationality = new Nationality
                {
                    Name = authorDTO.Nationality.Name,
                };
                _context.nationality.Add(nationality);
                _context.SaveChanges(); 
            }

            // Add the new Author
            var author = new Author
            {
                Name = authorDTO.Name,
                Phone = authorDTO.Phone,
                Email = authorDTO.Email,
                Nationality = nationality, // Use the fetched or newly created nationality
                Books = authorDTO.Books
                    .Where(b => !existingBookTitles.Contains(b.Title)) // Add only new books
                    .Select(b => new Book
                    {
                        Title = b.Title,
                        PublishedYear = b.PublishedYear
                    }).ToList()
            };

            // Add the author to the database
            _context.authors.Add(author);
            _context.SaveChanges();

            return authorDTO;
        }
        public AuthorDTO DeleteById(int id)
        {
            var author = _context.authors
                .Include(a => a.Books) 
                .FirstOrDefault(a => a.Id == id);

            if (author == null) return null;

            var authorDTO = new AuthorDTO
            {
                Name = author.Name,
                Phone = author.Phone,
                Email = author.Email,
                NationalityId = author.NationalityId,
                BooksId = author.Books.Select(b => b.Id).ToList()
            };

            _context.authors.Remove(author);
            _context.SaveChanges();

            return authorDTO;
        }

        public List<AuthorDTO> GetAll()
        {
            var authors = _context.authors
                .Include(a => a.Books) 
                .Select(a => new AuthorDTO
                {
                    Name = a.Name,
                    Phone = a.Phone,
                    Email = a.Email,
                    NationalityId = a.NationalityId,
                    BooksId = a.Books.Select(b => b.Id).ToList()
                }).ToList();

            return authors;
        }

        public AuthorDTO GetById(int id)
        {
            var author = _context.authors
                .Include(a => a.Books) 
                .FirstOrDefault(a => a.Id == id);

            if (author == null) return null;

            var authorDTO = new AuthorDTO
            {
                Name = author.Name,
                Phone = author.Phone,
                Email = author.Email,
                NationalityId = author.NationalityId,
                BooksId = author.Books.Select(b => b.Id).ToList()
            };

            return authorDTO;
        }

        public AuthorDTO Update(int id, AuthorDTO authorDTO)
        {
            var author = _context.authors
                .Include(a => a.Books) 
                .FirstOrDefault(a => a.Id == id);

            if (author == null) return null;

            author.Name = authorDTO.Name;
            author.Phone = authorDTO.Phone;
            author.Email = authorDTO.Email;
            author.NationalityId = authorDTO.NationalityId;

  
            if (authorDTO.BooksId != null && authorDTO.BooksId.Any())
            {
                var books = _context.books
                    .Where(b => authorDTO.BooksId.Contains(b.Id))
                    .ToList();

                author.Books = books;
            }

            _context.authors.Update(author);
            _context.SaveChanges();

            authorDTO.BooksId = author.Books.Select(b => b.Id).ToList();
            return authorDTO;
        }
    }


}


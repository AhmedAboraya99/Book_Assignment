using Book_Assignment.DTOs;
using Book_Assignment.Models;
using Book_Assignment.Repository.BookRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Book_Assignment.Repository.BookRepo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context) 
        {
            _context = context;
        }
        public BookDTO Add( BookDTO bookDTO)
        {
            //select existed authores
            var authors = _context.authors
                .Where(a => bookDTO.AuthorIds.Contains(a.Id)).ToList();

            var genres = _context.genre
                .Where(g => bookDTO.GenreIds.Contains(g.Id)).ToList();

            var book = new Book
            {
                Title = bookDTO.Title,
                PublishedYear = bookDTO.PublishedYear,
                Authors = authors,
                Genres = genres
            };
            if (book == null) { return null; }

            _context.books.Add(book);
            _context.SaveChanges();

            return bookDTO;
            
        }

        public BookDTO DeleteById(int id)
        {
            var book = _context.books.Find(id);

            if (book == null) return null;

            var bookdto = new BookDTO
            {
                Title = book.Title,
                PublishedYear = book.PublishedYear,
            };
            _context.books.Remove(book);
            _context.SaveChanges();

            return bookdto;
        }

        public List<BookToReturnDTO> GetAll()
        {
            var books = _context.books.Include(b => b.Authors).Include(b => b.Genres)
                .Select(b => new BookToReturnDTO
            {
                Title = b.Title,
                PublishedYear = b.PublishedYear,
                Authors = b.Authors.Select(x => new AuthorDTO
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    Email = x.Email,
                }).ToList(),

                Genres = b.Genres.Select(x => new GenreDTO
                {
                    Name = x.Name,
                }).ToList()

            }).ToList();

            return books;
        }

        public BookToReturnDTO GetById(int id)
        {
            var book = _context.books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(x => x.Id == id);

            var bookdto = new BookToReturnDTO
            {
                Title = book.Title,
                PublishedYear = book.PublishedYear,
                Authors = book.Authors.Select(a => new AuthorDTO
                {
                    Name = a.Name,
                    Phone = a.Phone,
                    Email = a.Email,
                }).ToList(),
                Genres = book.Genres.Select(g => new GenreDTO
                {
                    Name = g.Name
                }).ToList()

            };
            return bookdto;


        }

        public BookDTO Update(int Id, BookDTO bookDTO)
        {
            
            var book = _context.books.Find(Id);
            if (book == null)   return null;
            book.Title = bookDTO.Title;

            book.PublishedYear = bookDTO.PublishedYear;
                if (bookDTO.AuthorIds.Count() > 0)
                {
                    book.Authors = _context.authors
                    .Where(a => bookDTO.AuthorIds.Contains(a.Id)).ToList();
                }
                if (bookDTO.GenreIds.Count() > 0)
                {
                    book.Genres = _context.genre
                    .Where(a => bookDTO.GenreIds.Contains(a.Id)).ToList();
                }
                    _context.books.Update(book);
                    _context.SaveChanges();

            return bookDTO;
            }

        public BookToReturnDTO AddDataToBook(BookToReturnDTO bookDTO)
        {
            var existingAuthorNames = _context.authors.Select(a => a.Name).ToList();

            var book = new Book
            {
                Title = bookDTO.Title,
                PublishedYear = bookDTO.PublishedYear,
                //add  new authors
                // add
                Authors = bookDTO.Authors.Where(a => ! existingAuthorNames.Contains(a.Name)).Select(i => new Author
                {

                    Name = i.Name,
                    Email = i.Email,
                    Phone = i.Phone, 
                }
                
                ).ToList(),
                Genres = bookDTO.Genres.Select(i => new Genre
                {
                    Name = i.Name
                }).ToList()


            };
             var BookState = _context.books.Add(book);

            if (BookState == null) { return null; }
            _context.SaveChanges();
            return bookDTO;
        }
    }
}

using Book_Assignment.DTOs;
using Book_Assignment.Repository.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Book_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repo;

        public BooksController(IBookRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var booksdto = _repo.GetAll();

            if (booksdto == null)
            {
                return NotFound();
            }
            return Ok(booksdto);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookres = _repo.Add(bookdto);

            if (bookres == null)
            {
                return NotFound();
            }

            return Created();

        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var bookdto = _repo.GetById(id);
            if (bookdto == null)
                return NotFound();

            return Ok(bookdto);
        }
        [HttpPut]
        public IActionResult UpdateBook(int Id, BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booRes = _repo.Update(Id, bookDTO);


            if (booRes == null)
                return NotFound();

            return Ok(booRes);
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {

            var bookRes = _repo.DeleteById(id);
            if (bookRes == null)
                return NotFound();

            return Ok(bookRes);
        }
        [HttpPost("AddDataToBook")]
        public IActionResult AddDataToBook(BookToReturnDTO bookDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookRes = _repo.AddDataToBook(bookDTO);
            
            if(bookRes == null)
                return NotFound();

            return Ok(bookRes);
        }


    }
}

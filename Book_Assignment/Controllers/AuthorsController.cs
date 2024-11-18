using Author_Assignment.Repository.AuthorRepo;
using Book_Assignment.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;

        public AuthorsController(IAuthorRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorsdto = _repo.GetAll();

            if (authorsdto == null || !authorsdto.Any())
            {
                return NotFound();
            }
            return Ok(authorsdto);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDTO authordto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorres = _repo.Add(authordto);

            if (authorres == null)
            {
                return BadRequest("Unable to add the author.");
            }

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var authordto = _repo.GetById(id);

            if (authordto == null)
            {
                return NotFound();
            }

            return Ok(authordto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorDTO authordto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorres = _repo.Update(id, authordto);

            if (authorres == null)
            {
                return NotFound();
            }

            return Ok(authorres);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var authorres = _repo.DeleteById(id);

            if (authorres == null)
            {
                return NotFound();
            }

            return Ok(authorres);
        }

        [HttpPost("AddDataToAuthor")]
        public IActionResult AddDataToAuthor([FromBody] AuthorToReturnDTO authordto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorres = _repo.AddDataToAuthor(authordto);

            if (authorres == null)
            {
                return NotFound();
            }

            return Ok(authorres);
        }
    }
}


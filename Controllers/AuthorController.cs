using Microsoft.AspNetCore.Mvc;
using library.Entity;
using library.Interfaces.Services;

namespace library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Author> GetAll() => _service.GetAllAuthors();

        [HttpGet("{Id}")]
        public ActionResult<Author> GetAuthor(int Id)
        {
            var author = _service.GetAuthor(Id);
            return author == null ? NotFound() : Ok(author);
        }

        [HttpPost]
        public ActionResult<Author> AddAuthor(Author author)
        {
            var newAuthor = _service.AddAuthor(author);
            return CreatedAtAction(nameof(GetAuthor), new { Id = newAuthor.Id }, newAuthor);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateAuthor(int Id, Author author)
        {
            var existingAuthor = _service.GetAuthor(Id);
            if (existingAuthor == null) return NotFound();

            existingAuthor.Name = author.Name;

            _service.UpdateAuthor(existingAuthor);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _service.DeleteAuthor(Id);
            return NoContent();
        }
    }
}

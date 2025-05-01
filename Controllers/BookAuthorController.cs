using Microsoft.AspNetCore.Mvc;
using library.Entity;
using library.Interfaces.Services;

namespace library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookAuthorController : ControllerBase
    {
        private readonly IBookAuthorService _service;

        public BookAuthorController(IBookAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<BookAuthor> GetAll() => _service.GetAllBookAuthors();

        [HttpGet("{Id}")]
        public ActionResult<BookAuthor> GetBookAuthor(int Id)
        {
            var bookAuthor = _service.GetBookAuthor(Id);
            return bookAuthor == null ? NotFound() : Ok(bookAuthor);
        }

        [HttpPost]
        public ActionResult<BookAuthor> AddBookAuthor(BookAuthor bookAuthor)
        {
            var newBookAuthor = _service.AddBookAuthor(bookAuthor);
            return CreatedAtAction(nameof(GetBookAuthor), new { Id = newBookAuthor.Id }, newBookAuthor);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateBookAuthor(int Id, BookAuthor bookAuthor)
        {
            var existingBookAuthor = _service.GetBookAuthor(Id);
            if (existingBookAuthor == null) return NotFound();

            existingBookAuthor.BookId = bookAuthor.BookId;
            existingBookAuthor.AuthorId = bookAuthor.AuthorId;

            _service.UpdateBookAuthor(existingBookAuthor);
            return NoContent();
        }


        [HttpDelete("{Id}")]
        public IActionResult DeleteBookAuthor(int Id)
        {
            _service.DeleteBookAuthor(Id);
            return NoContent();
        }
    }
}

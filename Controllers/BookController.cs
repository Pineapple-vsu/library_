using Microsoft.AspNetCore.Mvc;
using library.Entity;
using library.Interfaces.Services;

namespace library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll() => _service.GetAllBooks();

        [HttpGet("{Id}")]
        public ActionResult<Book> GetBook(int Id)
        {
            var book = _service.GetBook(Id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            var newBook = _service.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { Id = newBook.Id }, newBook);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateBook(int Id, Book book)
        {
            if (Id != book.Id) return BadRequest();
            _service.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _service.DeleteBook(Id);
            return NoContent();
        }
    }
}

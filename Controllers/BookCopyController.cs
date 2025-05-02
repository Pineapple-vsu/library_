using library.Entity;
using library.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class BookCopyController : ControllerBase
    {
        private readonly IBookCopyService _service;

        public BookCopyController(IBookCopyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<BookCopy> GetAll() => _service.GetAllBookCopies();

        [HttpGet("{Id}")]
        public ActionResult<BookCopy> GetBookCopy(int Id)
        {
            var copy = _service.GetBookCopy(Id);
            return copy == null ? NotFound() : Ok(copy);
        }

        [HttpPost]
        public ActionResult<BookCopy> AddBookCopy(BookCopy copy)
        {
            var newCopy = _service.AddBookCopy(copy);
            return CreatedAtAction(nameof(GetBookCopy), new { Id = newCopy.Id }, newCopy);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateBookCopy(int Id, BookCopy copy)
        {
            var existingCopy = _service.GetBookCopy(Id);
            if (existingCopy == null) return NotFound();

            existingCopy.BookId = copy.BookId;
            existingCopy.StatusId = copy.StatusId;

            _service.UpdateBookCopy(existingCopy);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteBookCopy(int Id)
        {
            _service.DeleteBookCopy(Id);
            return NoContent();
        }
    }
}

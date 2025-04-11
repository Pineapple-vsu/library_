using Microsoft.AspNetCore.Mvc;
using library.Entity;
using library.Interfaces.Services;

namespace library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookStatusController : ControllerBase
    {
        private readonly IBookStatusService _service;

        public BookStatusController(IBookStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<BookStatus> GetAll() => _service.GetAllBooksStatuses();

        [HttpGet("{Id}")]
        public ActionResult<BookStatus> GetBookStatus(int Id)
        {
            var bookstatus = _service.GetBookStatus(Id);
            return bookstatus == null ? NotFound() : Ok(bookstatus);
        }

        [HttpPost]
        public ActionResult<BookStatus> AddBookStatus(BookStatus bookstatus)
        {
            var newBookStatus = _service.AddBookStatus(bookstatus);
            return CreatedAtAction(nameof(GetBookStatus), new { Id = newBookStatus.Id }, newBookStatus);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateBookStatus(int Id, BookStatus bookstatus)
        {
            var existingBookStatus = _service.GetBookStatus(Id);
            if (existingBookStatus == null) return NotFound();

            existingBookStatus.Name = bookstatus.Name;
           
            _service.UpdateBookStatus(existingBookStatus);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _service.DeleteBookStatus(Id);
            return NoContent();
        }
    }
}

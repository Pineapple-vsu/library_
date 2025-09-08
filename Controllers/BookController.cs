using Microsoft.AspNetCore.Mvc;
using library.Entity;
using library.Interfaces.Services;
using System.Collections.Generic;
using library.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "worker,admin")]
        [HttpGet]
        public IEnumerable<Book> GetAll() => _service.GetAllBooks();
        [Authorize(Roles = "worker,admin")]
        [HttpGet("{Id}")]
        public ActionResult<Book> GetBook(int Id)
        {
            var book = _service.GetBook(Id);
            return book == null ? NotFound() : Ok(book);
        }
        [Authorize(Roles = "worker,admin")]
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            var newBook = _service.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { Id = newBook.Id }, newBook);
        }
        [Authorize(Roles = "worker,admin")]
        [HttpPut("{Id}")]
        public IActionResult UpdateBook(int Id, Book book)
        {
            var existingBook = _service.GetBook(Id);
            if (existingBook == null) return NotFound();

            existingBook.Name = book.Name;
            existingBook.Isbn = book.Isbn;
            existingBook.Genre = book.Genre;
            existingBook.Description = book.Description;

            _service.UpdateBook(existingBook);
            return NoContent();

        }
        [Authorize(Roles = "worker,admin")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _service.DeleteBook(Id);
            return NoContent();
        }

        
        [HttpGet("availableBooks")]
        public ActionResult<IEnumerable<object>> GetAllAvailableBooks()
        {
            var availableBooks = _service.GetAvailableBooksByName("");
            if (availableBooks == null || !availableBooks.Any())
            {
                return NotFound();
            }

            var formattedResponse = availableBooks.Select(b => new
            {
                Book = b.book,
                FreeCopies = b.freeCopies,
                Copies = b.copies  
            });

            return Ok(formattedResponse);
        }

        [HttpGet("availableBooks/search")]
        public ActionResult<IEnumerable<object>> SearchAvailableBooksByName([FromQuery] string name)
        {
            var availableBooks = _service.GetAvailableBooksByName(name);
            if (availableBooks == null || !availableBooks.Any())
            {
                return NotFound();
            }

            var response = availableBooks.Select(b => new
            {
                Book = b.book,
                FreeCopies = b.freeCopies,
                Copies = b.copies 
            });
            return Ok(response);
        }


    }
}

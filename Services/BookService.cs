using library.Entity;
using library.Interfaces.Repositories;
using library.Interfaces.Services;

namespace library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Book> GetAllBooks() => _repository.GetAllBooks();

        public Book? GetBook(int Id) => _repository.GetBook(Id);

        public Book AddBook(Book Book) => _repository.AddBook(Book);

        public void UpdateBook(Book Book) => _repository.UpdateBook(Book);

        public void DeleteBook(int Id) => _repository.DeleteBook(Id);

        public IDictionary<Book, int> GetAvailableBooks() => _repository.GetAvailableBooks();

        public IEnumerable<(Book book, int freeCopies, IEnumerable<BookCopy> copies)> GetAvailableBooksByName(string name)
             => _repository.GetAvailableBooksByName(name);
    }
}

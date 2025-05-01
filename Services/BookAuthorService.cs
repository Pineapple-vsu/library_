using library.Entity;
using library.Interfaces.Repositories;
using library.Interfaces.Services;

namespace library.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly IBookAuthorRepository _repository;

        public BookAuthorService(IBookAuthorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookAuthor> GetAllBookAuthors() => _repository.GetAllBookAuthors();

        public BookAuthor? GetBookAuthor(int Id) => _repository.GetBookAuthor(Id);

        public BookAuthor AddBookAuthor(BookAuthor BookAuthor) => _repository.AddBookAuthor(BookAuthor);

        public void UpdateBookAuthor(BookAuthor BookAuthor) => _repository.UpdateBookAuthor(BookAuthor);

        public void DeleteBookAuthor(int Id) => _repository.DeleteBookAuthor(Id);
    }
}

using library.Entity;
using library.Interfaces.Repositories;
using library.Interfaces.Services;

namespace library.Services
{
    public class BookCopyService : IBookCopyService
    {
        private readonly IBookCopyRepository _repository;

        public BookCopyService(IBookCopyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookCopy> GetAllBookCopies() => _repository.GetAllBookCopies();

        public BookCopy GetBookCopy(int id) => _repository.GetBookCopy(id);

        public BookCopy AddBookCopy(BookCopy copy) => _repository.AddBookCopy(copy);

        public void UpdateBookCopy(BookCopy copy) => _repository.UpdateBookCopy(copy);

        public void DeleteBookCopy(int id) => _repository.DeleteBookCopy(id);

    }
}

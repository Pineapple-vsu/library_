using library.Entity;
using library.Interfaces.Repositories;
using library.Interfaces.Services;

namespace library.Services
{
    public class BookStatusService : IBookStatusService
    {
        private readonly IBookStatusRepository _repository;

        public BookStatusService(IBookStatusRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookStatus> GetAllBooksStatuses() => _repository.GetAllBooksStatuses();

        public BookStatus? GetBookStatus(int Id) => _repository.GetBookStatus(Id);

        public BookStatus AddBookStatus(BookStatus BookStatus) => _repository.AddBookStatus(BookStatus);

        public void UpdateBookStatus(BookStatus BookStatus) => _repository.UpdateBookStatus(BookStatus);

        public void DeleteBookStatus(int Id) => _repository.DeleteBookStatus(Id);
    }
}

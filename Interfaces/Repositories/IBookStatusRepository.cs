using library.Entity;
namespace library.Interfaces.Repositories
{
    public interface IBookStatusRepository
    {
        IEnumerable<BookStatus> GetAllBooksStatuses();
        BookStatus? GetBookStatus(int Id);
        BookStatus AddBookStatus(BookStatus bookstatus);
        void UpdateBookStatus(BookStatus bookstatus);
        void DeleteBookStatus(int Id);
    }
}

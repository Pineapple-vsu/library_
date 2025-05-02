using library.Entity;
namespace library.Interfaces.Repositories
{
    public interface IBookCopyRepository
    {
        IEnumerable<BookCopy> GetAllBookCopies();
        BookCopy GetBookCopy(int id);
        BookCopy AddBookCopy(BookCopy copy);
        void UpdateBookCopy(BookCopy copy);
        void DeleteBookCopy(int id);
    }
}

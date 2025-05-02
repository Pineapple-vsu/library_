using library.Entity;

namespace library.Interfaces.Services
{
    public interface IBookCopyService
    {
        IEnumerable<BookCopy> GetAllBookCopies();
        BookCopy GetBookCopy(int id);
        BookCopy AddBookCopy(BookCopy copy);
        void UpdateBookCopy(BookCopy copy);
        void DeleteBookCopy(int id);
    }
}

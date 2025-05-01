using library.Entity;

namespace library.Interfaces.Services
{
    public interface IBookAuthorService
    {
        IEnumerable<BookAuthor> GetAllBookAuthors();
        BookAuthor GetBookAuthor(int id);
        BookAuthor AddBookAuthor(BookAuthor bookAuthors);
        void UpdateBookAuthor(BookAuthor bookAuthors);
        void DeleteBookAuthor(int id);
    }
}

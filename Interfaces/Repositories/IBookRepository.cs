using library.Entity;
namespace library.Interfaces.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book? GetBook(int Id);
        Book AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int Id);
        IDictionary<Book, int> GetAvailableBooks();
        IEnumerable<(Book book, int freeCopies, IEnumerable<BookCopy> copies)> GetAvailableBooksByName(string name);

        IEnumerable<Book> GetBooksByGenre(Genre? genre);
        IEnumerable<(Book book, int freeCopies, IEnumerable<BookCopy> copies)> GetAvailableBooksByGenre(Genre? genre, string name = "");

    }
}

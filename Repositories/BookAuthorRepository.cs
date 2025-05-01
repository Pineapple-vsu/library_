using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly AppDbContext _db;

        public BookAuthorRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<BookAuthor> GetAllBookAuthors()
        {
            return _db.BookAuthor.Include(ba => ba.Book).Include(ba => ba.Author).ToList();
        }

        public BookAuthor GetBookAuthor(int id)
        {
            return _db.BookAuthor.Include(ba => ba.Book).Include(ba => ba.Author).FirstOrDefault(ba => ba.Id == id);
        }

        public BookAuthor AddBookAuthor(BookAuthor BookAuthor)
        {
            var book = _db.Book.Find(BookAuthor.BookId);
            var author = _db.Author.Find(BookAuthor.AuthorId);
            if (book == null || author == null)
            {
                throw new Exception($"Книга или Автор не найдены!");
            }

            BookAuthor.Book = book;
            BookAuthor.Author = author;
            _db.BookAuthor.Add(BookAuthor);
            _db.SaveChanges();
            return BookAuthor;
        }

        public void UpdateBookAuthor(BookAuthor BookAuthor)
        {
            _db.Entry(BookAuthor).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteBookAuthor(int id)
        {
            var BookAuthor = _db.BookAuthor.Find(id);
            if (BookAuthor != null)
            {
                _db.BookAuthor.Remove(BookAuthor);
                _db.SaveChanges();
            }
        }
    }
}

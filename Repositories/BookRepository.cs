using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _db.Book.ToList();
        }

        public Book GetBook(int id)
        {
            return _db.Book.First(s => s.Id == id);
        }

        public Book AddBook(Book book)
        {
            _db.Book.Add(book);
            _db.SaveChanges();
            return book;
        }

        public void UpdateBook(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _db.Book.Find(id);
            if (book != null)
            {
                _db.Book.Remove(book);
                _db.SaveChanges();
            }
        }
        public IDictionary<Book, int> GetAvailableBooks()
        {
            var freeCopies = _db.BookCopy
                .Include(bc => bc.Book)
                .Include(bc => bc.Status)
                .Where(bc => bc.Status != null && bc.Status.Name == "в библиотеке")
                .ToList();

            
            var availableBooks = freeCopies
                .GroupBy(bc => bc.Book)
                .ToDictionary(g => g.Key, g => g.Count());

            return availableBooks;
        }
        public IEnumerable<(Book book, int freeCopies, IEnumerable<BookCopy> copies)> GetAvailableBooksByName(string name)
        {
            string lowerName = name.ToLower();

            var freeCopies = _db.BookCopy
                .Include(bc => bc.Book)
                .Include(bc => bc.Status)
                .Where(bc => bc.Status != null &&
                             bc.Status.Name.ToLower() == "в библиотеке" &&
                             bc.Book.Name.ToLower().Contains(lowerName))
                .ToList();

            var availableBooks = freeCopies
                .GroupBy(bc => bc.Book)
                .Select(g => (book: g.Key, freeCopies: g.Count(), copies: g.AsEnumerable()))
                .ToList();

            return availableBooks;
        }

    }
}
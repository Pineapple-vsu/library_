using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        //public IEnumerable<Book> GetAllBooks() => _db.Book.AsNoTracking().ToList();



        //public Book? GetBook(int id) => _db.Book.AsNoTracking().FirstOrDefault(b => b.Id == id);


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
    }
}
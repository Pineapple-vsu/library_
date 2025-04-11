using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class BookStatusRepository : IBookStatusRepository
    {
        private readonly AppDbContext _db;

        public BookStatusRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<BookStatus> GetAllBooksStatuses()
        {
            return _db.BookStatus.ToList();
        }

        public BookStatus GetBookStatus(int id)
        {
            return _db.BookStatus.First(s => s.Id == id);
        }

        public BookStatus AddBookStatus(BookStatus bookstatus)
        {
            _db.BookStatus.Add(bookstatus);
            _db.SaveChanges();
            return bookstatus;
        }

        public void UpdateBookStatus(BookStatus bookstatus)
        {
            _db.Entry(bookstatus).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteBookStatus(int id)
        {
            var bookstatus = _db.BookStatus.Find(id);
            if (bookstatus != null)
            {
                _db.BookStatus.Remove(bookstatus);
                _db.SaveChanges();
            }
        }
    }
}
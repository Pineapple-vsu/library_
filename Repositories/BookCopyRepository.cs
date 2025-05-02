using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly AppDbContext _db;

        public BookCopyRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<BookCopy> GetAllBookCopies()
        {
            return _db.BookCopy.Include(c => c.Book).Include(c => c.Status).ToList();
        }

        public BookCopy GetBookCopy(int id)
        {
            return _db.BookCopy.Include(c => c.Book).Include(c => c.Status).FirstOrDefault(c => c.Id == id);
        }

        public BookCopy AddBookCopy(BookCopy copy)
        {
            var book = _db.Book.Find(copy.BookId);
            var status = _db.BookStatus.Find(copy.StatusId);
            if (book == null || status == null)
            {
                throw new Exception("Книга или статус не найдены!");
            }

            copy.Book = book;
            copy.Status = status;
            _db.BookCopy.Add(copy);
            _db.SaveChanges();
            return copy;
        }

        public void UpdateBookCopy(BookCopy copy)
        {
            _db.Entry(copy).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteBookCopy(int id)
        {
            var copy = _db.BookCopy.Find(id);
            if (copy != null)
            {
                _db.BookCopy.Remove(copy);
                _db.SaveChanges();
            }
        }
    }
}

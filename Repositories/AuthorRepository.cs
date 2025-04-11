using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _db;

        public AuthorRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _db.Author.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _db.Author.First(s => s.Id == id);
        }

        public Author AddAuthor(Author author)
        {
            _db.Author.Add(author);
            _db.SaveChanges();
            return author;
        }

        public void UpdateAuthor(Author author)
        {
            _db.Entry(author).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _db.Author.Find(id);
            if (author != null)
            {
                _db.Author.Remove(author);
                _db.SaveChanges();
            }
        }
    }
}
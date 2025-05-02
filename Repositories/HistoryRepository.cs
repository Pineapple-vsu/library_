using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly AppDbContext _db;

        public HistoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<History> GetAllHistories()
        {
            return _db.History.Include(h => h.Copy).Include(h => h.People).ToList();
        }

        public History GetHistory(int id)
        {
            return _db.History.Include(h => h.Copy).Include(h => h.People).FirstOrDefault(h => h.Id == id);
        }

        public History AddHistory(History history)
        {
            var copy = _db.BookCopy.Find(history.CopyId);
            var people = _db.People.Find(history.PeopleId);
            if (copy == null || people == null)
            {
                throw new Exception("Книга или пользователь не найдены!");
            }

            history.Copy = copy;
            history.People = people;
            _db.History.Add(history);
            _db.SaveChanges();
            return history;
        }

        public void UpdateHistory(History history)
        {
            _db.Entry(history).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteHistory(int id)
        {
            var history = _db.History.Find(id);
            if (history != null)
            {
                _db.History.Remove(history);
                _db.SaveChanges();
            }
        }
    }
}

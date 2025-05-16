using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _db;

        public PeopleRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<People> GetAllPeople()
        {
            return _db.People.Include(p => p.Role).ToList();
        }

        public People GetPeople(int id)
        {
            return _db.People.Include(p => p.Role).FirstOrDefault(p => p.Id == id);
        }

        public People AddPeople(People people)
        {
            var role = _db.Role.Find(people.RoleId);
            if (role == null)
            {
                throw new Exception($"Роль с ID {people.RoleId} не найдена!");
            }

            people.Role = role; // Привязываем роль вручную
            _db.People.Add(people);
            _db.SaveChanges();
            return people;
        }

        public void UpdatePeople(People people)
        {
            _db.Entry(people).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeletePeople(int id)
        {
            var people = _db.People.Find(id);
            if (people != null)
            {
                _db.People.Remove(people);
                _db.SaveChanges();
            }
        }
        public IEnumerable<History> GetUserHistoryWithBooks(int userId)
        {
            return _db.History
                      .Where(h => h.PeopleId == userId)
                      .Include(h => h.Copy)          
                      .ThenInclude(c => c.Book)      
                      .ToList();
        }

    }
}

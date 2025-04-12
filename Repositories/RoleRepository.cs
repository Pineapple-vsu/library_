using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _db;

        public RoleRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _db.Role.ToList();
        }

        public Role GetRole(int id)
        {
            return _db.Role.First(s => s.Id == id);
        }

        public Role AddRole(Role role)
        {
            _db.Role.Add(role);
            _db.SaveChanges();
            return role;
        }

        public void UpdateRole(Role role)
        {
            _db.Entry(role).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = _db.Role.Find(id);
            if (role != null)
            {
                _db.Role.Remove(role);
                _db.SaveChanges();
            }
        }
    }
}
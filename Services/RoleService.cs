using library.Entity;
using library.Interfaces.Repositories;
using library.Interfaces.Services;

namespace library.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Role> GetAllRoles() => _repository.GetAllRoles();

        public Role? GetRole(int Id) => _repository.GetRole(Id);

        public Role AddRole(Role Role) => _repository.AddRole(Role);

        public void UpdateRole(Role Role) => _repository.UpdateRole(Role);

        public void DeleteRole(int Id) => _repository.DeleteRole(Id);
    }
}

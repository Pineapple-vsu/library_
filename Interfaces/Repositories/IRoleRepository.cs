using library.Entity;
namespace library.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        Role? GetRole(int Id);
        Role AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int Id);
    }
}

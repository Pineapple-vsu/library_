using library.Entity;
namespace library.Interfaces.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        Role? GetRole(int Id);
        Role AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int Id);
    }
}

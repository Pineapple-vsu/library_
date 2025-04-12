using Microsoft.AspNetCore.Mvc;
using library.Entity;
using library.Interfaces.Services;

namespace library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Role> GetAll() => _service.GetAllRoles();

        [HttpGet("{Id}")]
        public ActionResult<Role> GetRole(int Id)
        {
            var role = _service.GetRole(Id);
            return role == null ? NotFound() : Ok(role);
        }

        [HttpPost]
        public ActionResult<Role> AddRole(Role role)
        {
            var newRole = _service.AddRole(role);
            return CreatedAtAction(nameof(GetRole), new { Id = newRole.Id }, newRole);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateRole(int Id, Role role)
        {
            var existingRole = _service.GetRole(Id);
            if (existingRole == null) return NotFound();

            existingRole.Name = role.Name;

            _service.UpdateRole(existingRole);
            return NoContent();

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _service.DeleteRole(Id);
            return NoContent();
        }
    }
}

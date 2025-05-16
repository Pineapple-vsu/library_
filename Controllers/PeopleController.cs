using library.Entity;
using library.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<People> GetAll() => _service.GetAllPeople();

        [HttpGet("{Id}")]
        public ActionResult<People> GetPeople(int Id)
        {
            var person = _service.GetPeople(Id);
            return person == null ? NotFound() : Ok(person);
        }

        [HttpPost]
        public ActionResult<People> AddPeople(People people)
        {
            var newPerson = _service.AddPeople(people);
            return CreatedAtAction(nameof(GetPeople), new { Id = newPerson.Id }, newPerson);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdatePeople(int Id, People people)
        {
            if (Id != people.Id) return BadRequest();
            _service.UpdatePeople(people);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletePeople(int Id)
        {
            _service.DeletePeople(Id);
            return NoContent();
        }
        [HttpGet("{userId}/historyBooks")]
        public ActionResult<IEnumerable<History>> GetUserHistoryBooks(int userId)
        {
            var historyBooks = _service.GetUserHistoryWithBooks(userId);
            if (historyBooks == null || !historyBooks.Any())
            {
                return NotFound();
            }
            return Ok(historyBooks);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using library.Entity;
using library.Interfaces.Services;

namespace library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _service;

        public HistoryController(IHistoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<History> GetAll() => _service.GetAllHistories();

        [HttpGet("{Id}")]
        public ActionResult<History> GetHistory(int Id)
        {
            var history = _service.GetHistory(Id);
            return history == null ? NotFound() : Ok(history);
        }

        [HttpPost]
        public ActionResult<History> AddHistory(History history)
        {
            var newHistory = _service.AddHistory(history);
            return CreatedAtAction(nameof(GetHistory), new { Id = newHistory.Id }, newHistory);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateHistory(int Id, History history)
        {
            var existingHistory = _service.GetHistory(Id);
            if (existingHistory == null) return NotFound();

            existingHistory.CopyId = history.CopyId;
            existingHistory.PeopleId = history.PeopleId;
            existingHistory.StartDate = history.StartDate;
            existingHistory.EndDate = history.EndDate;
            existingHistory.ReturnDate = history.ReturnDate;

            _service.UpdateHistory(existingHistory);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteHistory(int Id)
        {
            _service.DeleteHistory(Id);
            return NoContent();
        }

    }
}

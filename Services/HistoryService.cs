using library.Entity;
using library.Interfaces.Services;
using library.Interfaces.Repositories;


namespace library.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _repository;

        public HistoryService(IHistoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<History> GetAllHistories() => _repository.GetAllHistories();

        public History GetHistory(int id) => _repository.GetHistory(id);

        public History AddHistory(History history) => _repository.AddHistory(history);

        public void UpdateHistory(History history) => _repository.UpdateHistory(history);

        public void DeleteHistory(int id) => _repository.DeleteHistory(id);

        public IEnumerable<History> GetOverdueBooks()
        {
            return _repository.GetOverdueBooks();
        }
        public IEnumerable<History> GetBooksExpiringSoon()
        {
            return _repository.GetBooksExpiringSoon();
        }
    }
}

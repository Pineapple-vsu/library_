using library.Entity;
using library.Interfaces.Repositories;
using library.Interfaces.Services;

namespace library.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;

        public PeopleService(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<People> GetAllPeople() => _repository.GetAllPeople();

        public People? GetPeople(int Id) => _repository.GetPeople(Id);

        public People AddPeople(People People) => _repository.AddPeople(People);

        public void UpdatePeople(People People) => _repository.UpdatePeople(People);

        public void DeletePeople(int Id) => _repository.DeletePeople(Id);

        public IEnumerable<History> GetUserHistoryWithBooks(int userId)
        {
            return _repository.GetUserHistoryWithBooks(userId);
        }

    }
}

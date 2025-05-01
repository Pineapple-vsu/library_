using library.Entity;

namespace library.Interfaces.Repositories
{
    public interface IPeopleRepository
    {
        IEnumerable<People> GetAllPeople();
        People GetPeople(int id);
        People AddPeople(People people);
        void UpdatePeople(People people);
        void DeletePeople(int id);
    }
}

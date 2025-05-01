using library.Entity;

namespace library.Interfaces.Services
{
    public interface IPeopleService
    {
        IEnumerable<People> GetAllPeople();
        People GetPeople(int id);
        People AddPeople(People people);
        void UpdatePeople(People people);
        void DeletePeople(int id);
    }
}


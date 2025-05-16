using library.Entity;

namespace library.Interfaces.Services
{
    public interface IHistoryService
    {
        IEnumerable<History> GetAllHistories();
        History GetHistory(int id);
        History AddHistory(History history);
        void UpdateHistory(History history);
        void DeleteHistory(int id);
        IEnumerable<History> GetOverdueBooks();
        IEnumerable<History> GetBooksExpiringSoon();

    }
}

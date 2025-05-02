using library.Entity;
using System.Diagnostics.Metrics;

namespace library.Interfaces.Repositories
{
    public interface IHistoryRepository
    {
        IEnumerable<History> GetAllHistories();
        History GetHistory(int id);
        History AddHistory(History history);
        void UpdateHistory(History history);
        void DeleteHistory(int id);
    }
}

using meat_console_API.Entities;

namespace meat_console_API.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<int> Create(Session session);
        Task<IEnumerable<Session>> GetAll();

        Task<Session?> GetActiveSession();
    }
}

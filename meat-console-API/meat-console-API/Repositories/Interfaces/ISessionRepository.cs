using meat_console_API.Entities;

namespace meat_console_API.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<int> Create(Session newSession);
        Task<IEnumerable<Session>> GetAll();

        Task<Session?> GetActiveSession();

        Task<int> Update(Session updatedSession);
    }
}

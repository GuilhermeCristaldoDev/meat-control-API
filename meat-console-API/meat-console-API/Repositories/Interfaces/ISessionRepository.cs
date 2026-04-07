using meat_control_API.Entities;

namespace meat_control_API.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<int> Create(Session newSession);
        Task<IEnumerable<Session>> GetAll();

        Task<Session?> GetActiveSession();

        Task Update(Session updatedSession);
    }
}

using meat_console_API.Shared;

namespace meat_console_API.Repositories.Interfaces
{
    public interface ISessionService
    {
        Task<Result<int>> CreateSession();
    }
}

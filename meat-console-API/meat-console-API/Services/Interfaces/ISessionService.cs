using meat_console_API.DTOs;
using meat_console_API.Shared;

namespace meat_console_API.Services.Interfaces
{
    public interface ISessionService
    {
        Task<Result<int>> CreateSession();

        Task<Result> CloseSession();

        Task<Result<IEnumerable<GetSessionsResponseDto>>> ListAllSessions();
    }
}

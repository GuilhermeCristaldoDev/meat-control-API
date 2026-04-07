using meat_control_API.DTOs;
using meat_control_API.Shared;

namespace meat_control_API.Services.Interfaces
{
    public interface ISessionService
    {
        Task<Result<int>> CreateSession();

        Task<Result> CloseSession();

        Task<Result<IEnumerable<GetSessionsResponseDto>>> ListAllSessions();
    }
}

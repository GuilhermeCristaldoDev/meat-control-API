using meat_console_API.DTOs;
using meat_console_API.Entities;
using meat_console_API.Repositories.Interfaces;
using meat_console_API.Services.Interfaces;
using meat_console_API.Shared;

namespace meat_console_API.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repo;

        public SessionService(ISessionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<int>> CreateSession()
        {
            Session? activeSession = await _repo.GetActiveSession();

            if (activeSession is not null)
            {
                return Result<int>.Fail("Já existe uma sessão ativa!");
            }

            Session newSession = new();
            await _repo.Create(newSession);
            return Result<int>.Ok(newSession.Id);
        }

        public async Task<Result> CloseSession()
        {
            Session? activeSession = await _repo.GetActiveSession();

            if (activeSession is null)
            {
                return Result.Fail("Nenhuma sessão ativa!");
            }

            activeSession.CloseSession();
            await _repo.Update(activeSession);
            return Result.Ok();
        }

        public async Task<Result<IEnumerable<GetSessionsResponseDto>>> ListAllSessions()
        {
            var sessions = await _repo.GetAll();

            var sessionsDto = sessions.Select(s => new GetSessionsResponseDto
            {
                Id = s.Id,
                CreatedAt = s.CreatedAt,
                ClosedAt = s.ClosedAt,
                IsActive = s.IsActive,
                MeatCount = s.MeatCount,
            });

            return Result<IEnumerable<GetSessionsResponseDto>>.Ok(sessionsDto);
        }
    }
}

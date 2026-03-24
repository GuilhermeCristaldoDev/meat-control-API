using meat_console_API.Data;
using meat_console_API.Entities;
using meat_console_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace meat_console_API.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _context;

        public SessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Session newSession)
        {
            _context.Sessions.Add(newSession);
            await _context.SaveChangesAsync();

            return newSession.Id;
        }

        public async Task<IEnumerable<Session>> GetAll()
        {
            var sessions = await _context.Sessions.ToListAsync();

            return sessions;
        }

        public async Task<Session?> GetActiveSession()
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.IsActive == true);

            return session;
        }

        public async Task Update(Session updatedSession)
        {
            _context.Sessions.Update(updatedSession);
            await _context.SaveChangesAsync();
        }
    }
}

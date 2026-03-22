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

        public async Task<int> Create(Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            return session.Id;
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
    }
}

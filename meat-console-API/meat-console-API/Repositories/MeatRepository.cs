using meat_console_API.Data;
using meat_console_API.Entities;
using meat_console_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace meat_console_API.Repositories
{
    public class MeatRepository : IMeatRepository
    {
        private readonly AppDbContext _context;

        public MeatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Meat newMeat)
        {
            _context.Meats.Add(newMeat);
            await _context.SaveChangesAsync();

            return newMeat.Id;
        }

        public async Task<int> Delete(Meat meat)
        {
            _context.Meats.Remove(meat);
            await _context.SaveChangesAsync();

            return meat.Id;
        }

        public async Task<IEnumerable<Meat>> GetAll()
        {
            return await _context.Meats.ToListAsync();

        }

        public async Task<IEnumerable<Meat>> GetMeatsByOrderId(int orderId)
        {
            return await _context.Meats.Where(m => m.OrderId == orderId).ToListAsync();
        }

        public async Task<Meat?> GetById(int id)
        {
            return await _context.Meats.FindAsync(id);
        }

        public async Task<int> Update(Meat updatedMeat)
        {
            _context.Meats.Update(updatedMeat);
            await _context.SaveChangesAsync();

            return updatedMeat.Id;
        }

    }
}

using meat_console_API.Repositories.Interfaces;
using meat_console_API.Entities;
using meat_console_API.Data;
using Microsoft.EntityFrameworkCore;

namespace meat_console_API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            
            await _context.SaveChangesAsync();

            return newOrder.Id;
        }

        public async Task<int> Delete(Order order)
        {
            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<Order?> GetById(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);

            return order;
        }

        public async Task<Order?> GetActiveOrder()
        {
            Order? order = await _context.Orders.FirstOrDefaultAsync(o => o.Status == Enums.OrderStatus.Open);

            return order;
        }

        public async Task Update(Order updatedOrder)
        {
            _context.Orders.Update(updatedOrder);
            await _context.SaveChangesAsync();
        }
    }
}

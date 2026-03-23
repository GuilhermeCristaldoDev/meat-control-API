using meat_console_API.Entities;

namespace meat_console_API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> Create(Order newOrder);

        Task<int> Delete(Order order);

        Task<IEnumerable<Order>> GetAll();

        Task<Order?> GetById(int id);

        Task<int> Update(Order updatedOrder);
    }
}

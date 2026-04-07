using meat_control_API.Entities;

namespace meat_control_API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> Create(Order newOrder);

        Task<int> Delete(Order order);
        Task<IEnumerable<Order>> GetAll();
        Task<Order?> GetById(int id);
        Task<Order?> GetActiveOrder();
        Task<Order?> GetActiveOrderWithMeats();
        Task Update(Order updatedOrder);
    }
}

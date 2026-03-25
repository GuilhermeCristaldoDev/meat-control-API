using meat_console_API.Entities;

namespace meat_console_API.Repositories.Interfaces
{
    public interface IMeatRepository
    {
        Task<int> Create(Meat newMeat);

        Task<int> Delete(Meat meat);

        Task<IEnumerable<Meat>> GetAll();
        Task<IEnumerable<Meat>> GetMeatsByOrderId(int orderId);

        Task<Meat?> GetById(int id);

        Task<int> Update(Meat updatedMeat);
    }
}

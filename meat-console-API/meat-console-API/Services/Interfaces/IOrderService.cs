using meat_console_API.DTOs;
using meat_console_API.Shared;

namespace meat_console_API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Result<CreateOrderResponseDto>> CreateOrder();
        Task<Result<CloseOrderResponseDto>> CloseOrder();
        Task<Result<IEnumerable<GetOrderResponseDto>>> ListAllOrders();
        Task<Result<int>> AddMeatToOrder(int meatId);
        Task<Result<int>> RemoveMeatFromOrder(int meatId);
        Task<Result<GetOrderResponseDto?>> GetOrderById(int orderId);
        Task<Result> CancelOrder();
    }
}

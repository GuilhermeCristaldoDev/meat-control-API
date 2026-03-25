using meat_console_API.DTOs;
using meat_console_API.Shared;

namespace meat_console_API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Result<CreateOrderResponseDto>> CreateOrder();
        Task<Result<GetOrderResponseDto>> CloseOrder();
        Task<Result<IEnumerable<GetOrderResponseDto>>> ListAllOrders();
        Task<Result<GetOrderResponseDto?>> GetOrderById(int orderId);
        Task<Result> CancelOrder();
    }
}

using meat_console_API.DTOs;
using meat_console_API.Repositories.Interfaces;
using meat_console_API.Services.Interfaces;
using meat_console_API.Entities;
using meat_console_API.Shared;

namespace meat_console_API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ISessionRepository _sessionRepo;

        public OrderService(IOrderRepository orderRepo, ISessionRepository sessionRepo)
        {
            _orderRepo = orderRepo;
            _sessionRepo = sessionRepo;
        }

        public async Task<Result<CreateOrderResponseDto>> CreateOrder()
        {
            Session? sessionActive = await _sessionRepo.GetActiveSession();

            if (sessionActive is null)
                return Result<CreateOrderResponseDto>.Fail("Não há nenhuma sessão ativa");

            Order order = new(sessionActive.Id);

            await _orderRepo.Create(order);

            CreateOrderResponseDto responseDto = new(order.Id);

            return Result<CreateOrderResponseDto>.Ok(responseDto);
        }

        public async Task<Result> CloseOrder()
        {
            Order? order = await _orderRepo.GetActiveOrder();

            if (order is null)
                return Result.Fail("Não há nenhuma venda aberta");

            order.CloseOrder();
            await _orderRepo.Update(order);
            return Result.Ok();
        }
    }
}

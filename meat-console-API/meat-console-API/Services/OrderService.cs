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
        private readonly IMeatRepository _meatRepo;

        public OrderService(IOrderRepository orderRepo, ISessionRepository sessionRepo, IMeatRepository meatRepo)
        {
            _orderRepo = orderRepo;
            _sessionRepo = sessionRepo;
            _meatRepo = meatRepo;

        }

        public async Task<Result<CreateOrderResponseDto>> CreateOrder()
        {
            Session? sessionActive = await _sessionRepo.GetActiveSession();

            if (sessionActive is null)
                return Result<CreateOrderResponseDto>.Fail("Não há nenhuma sessão ativa");

            Order? order = await _orderRepo.GetActiveOrder();

            if (order is not null)
                return Result<CreateOrderResponseDto>.Fail("Já existe uma venda ativa");

            order = new(sessionActive.Id);

            await _orderRepo.Create(order);

            CreateOrderResponseDto responseDto = new(order.Id);

            return Result<CreateOrderResponseDto>.Ok(responseDto);
        }

        public async Task<Result<CloseOrderResponseDto>> CloseOrder()
        {
            Order? order = await _orderRepo.GetActiveOrderWithMeats();

            if (order is null)
                return Result<CloseOrderResponseDto>.Fail("Não há nenhuma venda aberta");

            
            order.Close();
            await _orderRepo.Update(order);

            var orderDto = new CloseOrderResponseDto
            {
                Id = order.Id,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                ClosedAt = order.ClosedAt,
                TotalAmount = order.TotalAmount,
                Meats = [.. order.Meats.Select(m => new GetMeatResponseDto
                {
                    Id = m.Id,
                    MeatNumber = m.MeatNumber,
                    OrderId = m.OrderId,
                    Status = m.Status,
                    Cut = m.Cut,
                    PriceKg = m.PriceKg,
                    WeightKg = m.WeightKg,
                    TotalPrice = m.TotalPrice,
                })],
            };

            return Result<CloseOrderResponseDto>.Ok(orderDto);
        }

        public async Task<Result<IEnumerable<GetOrderResponseDto>>> ListAllOrders()
        {
            var orders = await _orderRepo.GetAll();

            var ordersDto = orders.Select(o => new GetOrderResponseDto
            {
                Id = o.Id,
                Status = o.Status,
                CreatedAt = o.CreatedAt,
                ClosedAt = o.ClosedAt,
                TotalAmount = o.TotalAmount,
            });

            return Result<IEnumerable<GetOrderResponseDto>>.Ok(ordersDto);
        }

        public async Task<Result<GetOrderResponseDto?>> GetOrderById(int orderId)
        {
            Order? order = await _orderRepo.GetById(orderId);

            if (order is null)
                return Result<GetOrderResponseDto?>.Fail("Essa venda não existe");

            var orderDto = new GetOrderResponseDto
            {
                Id = order.Id,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                ClosedAt = order.ClosedAt,
                TotalAmount = order.TotalAmount,
            };

            return Result<GetOrderResponseDto?>.Ok(orderDto);
        }

        public async Task<Result> CancelOrder()
        {
            Order? order = await _orderRepo.GetActiveOrder();

            if (order is null)
                return Result.Fail("Nenhuma venda aberta");

            var meats = await _meatRepo.GetMeatsByOrderId(order.Id);

            foreach (var meat in meats)
            {
                meat.Release();
                await _meatRepo.Update(meat);
            }

            order.Cancel();
            await _orderRepo.Update(order);
            return Result.Ok();
        }
    }
}

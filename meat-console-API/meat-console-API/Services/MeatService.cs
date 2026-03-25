using meat_console_API.DTOs;
using meat_console_API.Entities;
using meat_console_API.Enums;
using meat_console_API.Pricing;
using meat_console_API.Repositories.Interfaces;
using meat_console_API.Services.Interfaces;
using meat_console_API.Shared;
using System.Reflection;

namespace meat_console_API.Services
{
    public class MeatService : IMeatService
    {
        private readonly IMeatRepository _meatRepo;
        private readonly ISessionRepository _sessionRepo;
        private readonly IOrderRepository _orderRepo;

        public MeatService(IMeatRepository meatRepo, ISessionRepository sessionRepo, IOrderRepository orderRepo)
        {
            _meatRepo = meatRepo;
            _sessionRepo = sessionRepo;
            _orderRepo = orderRepo;
        }

        public async Task<Result<CreateMeatResponseDto>> CreateMeat(CreateMeatRequestDto meatDto)
        {
            Session? session = await _sessionRepo.GetActiveSession();

            if (session is null)
                return Result<CreateMeatResponseDto>.Fail("Nenhuma sessão ativa, erro ao cadastrar carne");

            if (!Enum.IsDefined(meatDto.Cut))
                return Result<CreateMeatResponseDto>.Fail("Tipo de carne invalido");

            int meatCount = session.GetNextMeatNumber();
            decimal priceKg = MeatPricing.DefaultPrices[meatDto.Cut];

            Meat meat = new(meatCount, meatDto.Cut, priceKg, meatDto.WeightKg);

            await _meatRepo.Create(meat);
            return Result<CreateMeatResponseDto>.Ok(new CreateMeatResponseDto(meat.Id));
        }

        public async Task<Result> DeleteMeat(int meatId)
        {
            Meat? meat = await _meatRepo.GetById(meatId);

            if (meat is null)
                return Result.Fail("Essa carne não existe");

            await _meatRepo.Delete(meat);
            return Result.Ok();
        }

        public async Task<Result<IEnumerable<GetMeatResponseDto>>> ListAllMeats()
        {
            var meats = await _meatRepo.GetAll();

            var meatsDto = meats.Select(m => new GetMeatResponseDto
            {
                Id = m.Id,
                MeatNumber = m.MeatNumber,
                Status = m.Status,
                OrderId = m.OrderId,
                Cut = m.Cut,
                PriceKg = m.PriceKg,
                WeightKg = m.WeightKg,
                TotalPrice = m.TotalPrice
            });

            return Result<IEnumerable<GetMeatResponseDto>>.Ok(meatsDto);
        }

        public async Task<Result<GetMeatResponseDto?>> GetMeatById(int meatId)
        {
            Meat? meat = await _meatRepo.GetById(meatId);

            if (meat is null)
                return Result<GetMeatResponseDto?>.Fail("Essa carne não existe");

            GetMeatResponseDto meatDto = new()
            {
                Id = meat.Id,
                MeatNumber = meat.MeatNumber,
                OrderId = meat.OrderId,
                Status = meat.Status,
                Cut = meat.Cut,
                PriceKg = meat.PriceKg,
                WeightKg = meat.WeightKg,
                TotalPrice = meat.TotalPrice
            };


            return Result<GetMeatResponseDto?>.Ok(meatDto);
        }

        public async Task<Result> ReserveMeat(int meatId, string clientName)
        {
            Session? activeSession = await _sessionRepo.GetActiveSession();

            if (activeSession is null)
                return Result.Fail("Nenhuma sessão ativa. Você não pode reservar carnes!");

            Meat? meat = await _meatRepo.GetById(meatId);

            if (meat is null)
                return Result.Fail("Essa carne não existe");

            if (meat.Status != Enums.MeatStatus.Available)
                return Result.Fail("Essa carne já foi reservada ou vendida");

            meat.Reserve(clientName);
            await _meatRepo.Update(meat);
            return Result.Ok();
        }

        public async Task<Result> SellMeat(int meatId)
        {
            Session? activeSession = await _sessionRepo.GetActiveSession();

            if (activeSession is null)
                return Result.Fail("Nenhuma sessão ativa. Você não pode reservar carnes!");

            Order? activeOrder = await _orderRepo.GetActiveOrder();

            if (activeOrder is null)
                return Result.Fail("Nenhuma order ativa. Você não pode vender carnes!");

            Meat? meat = await _meatRepo.GetById(meatId);

            if (meat is null)
                return Result.Fail("Essa carne não existe");

            if (meat.Status == Enums.MeatStatus.Sold)
                return Result.Fail("Essa carne já foi vendida");

            meat.Sell(activeOrder.Id);
            await _meatRepo.Update(meat);
            return Result.Ok();
        }

        public async Task<Result> EditMeat(UpdateMeatRequestDto meatDto, int meatId)
        {
            if (meatDto.Cut is null && meatDto.WeightKg is null)
                return Result.Fail("Não é possivel editar com campos vazios");

            Meat? meat = await _meatRepo.GetById(meatId);

            if (meat is null)
                return Result.Fail("Essa carne não existe");

            if (meat.Status == MeatStatus.Sold)
                return Result.Fail("Essa carne não pode ser editada");

            if (meatDto.Cut is not null)
                meat.EditCut(meatDto.Cut.Value);

            if (meatDto.WeightKg is not null)
                meat.EditWeightKg(meatDto.WeightKg.Value);

            await _meatRepo.Update(meat);
            return Result.Ok();
        }
    }
}

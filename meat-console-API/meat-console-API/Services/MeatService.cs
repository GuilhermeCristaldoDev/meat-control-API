using meat_console_API.DTOs;
using meat_console_API.Repositories.Interfaces;
using meat_console_API.Services.Interfaces;
using meat_console_API.Shared;
using meat_console_API.Entities;
using meat_console_API.Pricing;
using meat_console_API.Enums;

namespace meat_console_API.Services
{
    public class MeatService : IMeatService
    {
        private readonly IMeatRepository _meatRepo;
        private readonly ISessionRepository _sessionRepo;

        public MeatService(IMeatRepository meatRepo, ISessionRepository sessionRepo)
        {
            _meatRepo = meatRepo;
            _sessionRepo = sessionRepo;
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
                IsAvailable = m.IsAvailable,
                OrderId = m.OrderId,
                IsReserved = m.IsReserved,
                Cut = m.Cut,
                PriceKg = m.PriceKg,
                WeightKg = m.WeightKg,
                TotalPrice = m.TotalPrice
            });

            return Result<IEnumerable<GetMeatResponseDto>>.Ok(meatsDto);
        }
    }
}

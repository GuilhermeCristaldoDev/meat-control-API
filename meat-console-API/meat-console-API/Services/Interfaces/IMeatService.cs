using meat_console_API.DTOs;
using meat_console_API.Shared;

namespace meat_console_API.Services.Interfaces
{
    public interface IMeatService
    {
        Task<Result<CreateMeatResponseDto>> CreateMeat(CreateMeatRequestDto meatDto);

        Task<Result> DeleteMeat(int meatId);
    }
}

using meat_console_API.DTOs;
using meat_console_API.Shared;
using meat_console_API.Entities;

namespace meat_console_API.Services.Interfaces
{
    public interface IMeatService
    {
        Task<Result<CreateMeatResponseDto>> CreateMeat(CreateMeatRequestDto meatDto);
        Task<Result> DeleteMeat(int meatId);
        Task<Result<IEnumerable<GetMeatResponseDto>>> ListAllMeats();
        Task<Result<GetMeatResponseDto?>> GetMeatById(int meatId);
        Task<Result> ReserveMeat(int meatId, string clientName);
        Task<Result> UnreserveMeat(int meatId);
        Task<Result> EditMeat(UpdateMeatRequestDto meatDto, int meatId);
       
    }
}

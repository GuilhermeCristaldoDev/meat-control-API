using meat_console_API.Entities;
using meat_console_API.Enums;

namespace meat_console_API.DTOs
{
    public class GetMeatResponseDto
    {
        public int Id { get;  set; }
        public int MeatNumber { get;  set; }
        public int? OrderId { get;  set; }
        public bool IsAvailable { get;  set; }
        public bool IsReserved { get;  set; }
        public MeatCut Cut { get;  set; }
        public decimal PriceKg { get;  set; }
        public decimal WeightKg { get;  set; }
        public decimal TotalPrice { get;  set; }
    }
}

using meat_console_API.Enums;
using meat_console_API.Entities;

namespace meat_console_API.DTOs
{
    public class CloseOrderResponseDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<GetMeatResponseDto>? Meats { get; set; }
    }
}

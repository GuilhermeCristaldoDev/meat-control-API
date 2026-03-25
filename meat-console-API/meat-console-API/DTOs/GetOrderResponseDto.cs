using meat_console_API.Entities;
using meat_console_API.Enums;

namespace meat_console_API.DTOs
{
    public class GetOrderResponseDto
    {
        public int Id { get; set; }
        public OrderStatus Status{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

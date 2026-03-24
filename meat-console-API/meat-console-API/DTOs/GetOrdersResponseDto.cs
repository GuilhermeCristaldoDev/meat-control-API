using meat_console_API.Entities;

namespace meat_console_API.DTOs
{
    public class GetOrdersResponseDto
    {
        public int Id { get;  set; }
        public bool IsActive { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime? ClosedAt { get;  set; }
    }
}

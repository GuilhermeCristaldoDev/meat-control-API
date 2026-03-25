using meat_console_API.DTOs;
using meat_console_API.Enums;

namespace meat_console_API.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int SessionId { get; private set; }
        public Session Session { get; private set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }
        public decimal TotalAmount { get; private set; }
        public ICollection<Meat> Meats { get; set; }

        public Order(int sessionId)
        {
            SessionId = sessionId;
            Status = OrderStatus.Open;
            CreatedAt = DateTime.Now;
        }

        public void Close()
        {
            ClosedAt = DateTime.Now;
            Status = OrderStatus.Closed;
            TotalAmount = GetTotalAmount();
        }

        public void Cancel()
        {
            ClosedAt = DateTime.Now;
            Status = OrderStatus.Canceled;
        }

        public decimal GetTotalAmount()
        {
            return Meats.Sum(m => m.TotalPrice);
        }
    }
}

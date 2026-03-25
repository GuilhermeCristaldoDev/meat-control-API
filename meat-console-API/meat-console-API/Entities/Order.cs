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

        public Order(int sessionId)
        {
            SessionId = sessionId;
            Status = OrderStatus.Open;
            CreatedAt = DateTime.Now;
        }

        public void Close(decimal totalAmount)
        {
            ClosedAt = DateTime.Now;
            Status = OrderStatus.Closed;
            TotalAmount = totalAmount;
        }
    }
}

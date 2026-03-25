namespace meat_console_API.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int SessionId { get; private set; }
        public Session Session { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Order(int sessionId)
        {
            SessionId = sessionId;
            IsActive = true;
            CreatedAt = DateTime.Now;
        }

        public void CloseOrder(decimal totalAmount)
        {
            ClosedAt = DateTime.Now;
            IsActive = false;
            TotalAmount = totalAmount;
        }
    }
}

namespace meat_console_API.Entities
{
    public class Session
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }
        public bool IsActive { get; private set; }

        public Session()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public void CloseSession()
        {
            IsActive = false;
            ClosedAt = DateTime.Now;
        }
    }
}

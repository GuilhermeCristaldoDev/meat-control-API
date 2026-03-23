namespace meat_console_API.DTOs
{
    public class GetSessionsResponseDto
    {
        public int Id { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime? ClosedAt { get;  set; }
        public int MeatCount { get;  set; }
        public bool IsActive { get;  set; }
    }
}

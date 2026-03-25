using meat_console_API.Enums;

namespace meat_console_API.DTOs
{
    public class UpdateMeatRequestDto
    {
        public MeatCut? Cut { get; set; }
        public decimal? WeightKg { get; set; }
    }
}

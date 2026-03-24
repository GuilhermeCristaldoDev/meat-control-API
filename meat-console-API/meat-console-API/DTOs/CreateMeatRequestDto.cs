using meat_console_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace meat_console_API.DTOs
{
    public class CreateMeatRequestDto
    {
        [Required]
        public MeatCut Cut { get; set; }

        [Range(0.001, double.MaxValue, ErrorMessage = "Peso deve ser maior que zero")]
        public decimal WeightKg { get; set; }
    }
}

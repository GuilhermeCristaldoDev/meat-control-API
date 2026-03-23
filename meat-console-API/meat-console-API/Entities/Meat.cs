using meat_console_API.Enums;

namespace meat_console_API.Entities
{
    public class Meat
    {
        public int Id { get; private set; }
        public int MeatNumber { get; private set; }
        public int? OrderId { get; private set; }
        public Order? Order { get; private set; }
        public bool IsAvailable { get; private set; }
        public bool IsReserved { get; private set; }
        public string? ReservedBy { get; private set; }
        public MeatCut Cut { get; private set; }
        public decimal PriceKg { get; private set; }
        public decimal WeightKg { get; private set; }
        public decimal TotalPrice { get; private set; }

        private Meat()
        {

        }

        public Meat(int meatNumber, MeatCut cut, decimal priceKg, decimal weightKg)
        {
            MeatNumber = meatNumber;
            IsAvailable = false;
            IsReserved = false;
            Cut = cut;
            PriceKg = priceKg;
            WeightKg = weightKg;
            TotalPrice = CalculateMeatPrice();
        }

        private decimal CalculateMeatPrice()
        {
            return Math.Round((PriceKg * WeightKg) - 10);
        }

        public void ReserveMeat(string clientName)
        {
            ReservedBy = clientName;
            IsReserved = true;
            IsAvailable = false;
        }
    }
}

using meat_console_API.Enums;

namespace meat_console_API.Entities
{
    public class Meat
    {
        public int Id { get; private set; }
        public int MeatNumber { get; private set; }
        public int? OrderId { get; private set; }
        public Order? Order { get; private set; }
        public MeatStatus Status { get; private set; }
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
            Status = MeatStatus.Available;
            Cut = cut;
            PriceKg = priceKg;
            WeightKg = weightKg;
            TotalPrice = CalculateMeatPrice();
        }

        private decimal CalculateMeatPrice()
        {
            return Math.Round((PriceKg * WeightKg) - 10);
        }

        public Meat Split()
        {
            WeightKg = WeightKg / 2;
            TotalPrice = CalculateMeatPrice();

            return new Meat(MeatNumber, Cut, PriceKg, WeightKg);
        }

        public void Reserve(string clientName)
        {
            ReservedBy = clientName;
            Status = MeatStatus.Reserved;
        }

        public void Sell(int orderId)
        {
            OrderId = orderId;
            Status = MeatStatus.Sold;
        }
    }
}

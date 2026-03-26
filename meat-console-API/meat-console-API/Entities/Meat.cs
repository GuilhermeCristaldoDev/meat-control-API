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
            TotalPrice = CalculateTotalPrice();
        }

        public decimal CalculateTotalPrice()
        {
            return Math.Round((PriceKg * WeightKg) - 10);
        }

        public Meat Split()
        {
            WeightKg = WeightKg / 2;
            TotalPrice = CalculateTotalPrice();

            return new Meat(MeatNumber, Cut, PriceKg, WeightKg);
        }

        public void Reserve(string clientName)
        {
            ReservedBy = clientName;
            Status = MeatStatus.Reserved;
        }

        public void Sell()
        {
            Status = MeatStatus.Sold;
        }

        public void Release()
        {
            OrderId = null;
            Status = MeatStatus.Available;
            ReservedBy = null;

        }

        public void Unreserve()
        {
            Status = MeatStatus.Available;
            ReservedBy = null;
        }

        public void AddMeatToOrder(int orderId)
        {
            OrderId = orderId;
            Status = MeatStatus.InOrder;
        }

        public void EditWeightKg(decimal weightKg)
        {
            WeightKg = weightKg;
            TotalPrice = CalculateTotalPrice();
        }

        public void EditCut(MeatCut newCut)
        {
            Cut = newCut;
        }
    }
}

using meat_control_API.Enums;

namespace meat_control_API.Pricing
{
    public class MeatPricing
    {
        public static readonly Dictionary<MeatCut, decimal> DefaultPrices = new()
        {
            { MeatCut.Pacuzinho, 75.00m },
            { MeatCut.Fraldinha, 75.00m },
            { MeatCut.CapaDoCoxaoMole, 75.00m },
            { MeatCut.Granito, 75.00m },
            { MeatCut.ContraFile, 75.00m },
            { MeatCut.PontaDeCostela, 75.00m },
            { MeatCut.Costela, 40.00m }

        };

         
    }
}

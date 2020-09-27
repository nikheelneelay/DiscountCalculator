using PromotionEngine.Common;
using PromotionEngine.Services.Interfaces;

namespace PromotionEngine.Services.Implementation
{
    public class PricingService : IPricingService
    {
        public decimal GetDefaultRateForSKUs(SKUProduct product)
        {
            //TODO - Re factor to fetch default prices from persistent source
            switch (product)
            {
                case SKUProduct.A:
                    return 50;

                case SKUProduct.B:
                    return 30;

                case SKUProduct.C:
                    return 20;

                case SKUProduct.D:
                    return 15;

                default:
                    return 0;
            }
        }
    }
}
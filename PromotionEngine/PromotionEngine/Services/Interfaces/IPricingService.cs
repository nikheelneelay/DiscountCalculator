using PromotionEngine.Common;

namespace PromotionEngine.Services.Interfaces
{
    public interface IPricingService
    {
        public decimal GetDefaultRateForSKUs(SKUProduct product);
    }
}
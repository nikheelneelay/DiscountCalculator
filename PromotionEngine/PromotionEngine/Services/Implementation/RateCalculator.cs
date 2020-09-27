using PromotionEngine.Common;
using PromotionEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Services.Implementation
{
    public class RateCalculator : IRateCalculator
    {
        public RateCalculator(IPricingService pricingService)
        {
            PricingService = pricingService;
        }

        public IPricingService PricingService { get; }

        public decimal CalculateRate(Dictionary<SKUProduct, int> orderData)
        {
            var totalPrice = orderData.Sum(x => PricingService.GetDefaultRateForSKUs(x.Key) * x.Value);

            return totalPrice;
        }
    }
}

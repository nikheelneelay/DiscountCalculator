using PromotionEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Services.Implementation
{
    public interface IPricingService
    {
        public decimal GetDefaultRateForSKUs(SKUProduct product)
        {
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

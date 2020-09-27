using PromotionEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Services.Interfaces
{
    public interface IPricingService
    {
        public decimal GetDefaultRateForSKUs(SKUProduct product);
    }
}

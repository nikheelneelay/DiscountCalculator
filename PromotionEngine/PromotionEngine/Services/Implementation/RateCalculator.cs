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
        public decimal CalculateRate(Dictionary<SKUProducts, int> orderData)
        {
            throw new NotImplementedException();
        }
    }
}

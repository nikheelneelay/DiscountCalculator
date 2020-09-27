using PromotionEngine.Common;
using System.Collections.Generic;

namespace PromotionEngine.Services.Interfaces
{
    public interface IRateCalculatorService
    {
        decimal CalculateRate(Dictionary<SKUProduct, int> orderData);

        decimal CalculateRateWithPromotions(Dictionary<SKUProduct, int> orderData);
    }
}
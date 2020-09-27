using PromotionEngine.Common;
using PromotionEngine.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PromotionEngine.Test
{
    public class PricingServiceTest
    {
        [Fact]
        public void RateCalculator_MockData_DecimalData()
        {
            var pricingService = new PricingService();

            var defaultRate = pricingService.GetDefaultRateForSKUs(SKUProduct.A);

            Assert.Equal(50, defaultRate);

        }
    }
}

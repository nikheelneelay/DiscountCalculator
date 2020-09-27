using PromotionEngine.Common;
using PromotionEngine.Services.Implementation;
using Xunit;

namespace PromotionEngine.Test
{
    public class PricingServiceTest
    {
        [Fact]
        public void GetDefaultRate_SKUProduct_DefaultRate()
        {
            var pricingService = new PricingService();

            var defaultRate = pricingService.GetDefaultRateForSKUs(SKUProduct.A);

            Assert.Equal(50, defaultRate);
        }
    }
}
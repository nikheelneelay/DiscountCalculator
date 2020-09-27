using Moq;
using PromotionEngine.Common;
using PromotionEngine.Services.Implementation;
using PromotionEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Test
{
    public class RateCalculatorTest
    {
        [Fact]
        public void RateCalculator_MockData_DecimalData()
        {
            var mockPricingService = new Mock<IPricingService>();

            var rateCal = new RateCalculator(mockPricingService.Object);

            var totalPrice = rateCal.CalculateRate(GetMockOrderData());

            Assert.NotNull(totalPrice);

        }

        [Fact]
        public void RateCalculator_MockData_PricingServiceCalled()
        {
            var mockPricingService = new Mock<IPricingService>();

            var rateCal = new RateCalculator(mockPricingService.Object);

            var totalPrice = rateCal.CalculateRate(GetMockOrderData());

            mockPricingService.Verify(x => x.GetDefaultRateForSKUs(SKUProduct.A), Times.Once);
            mockPricingService.Verify(x => x.GetDefaultRateForSKUs(SKUProduct.B), Times.Once);
            mockPricingService.Verify(x => x.GetDefaultRateForSKUs(SKUProduct.C), Times.Once);
            mockPricingService.Verify(x => x.GetDefaultRateForSKUs(SKUProduct.D), Times.Once);

        }

        public Dictionary<SKUProduct, int> GetMockOrderData()
        {
            var orderData = new Dictionary<SKUProduct, int>
            {
                { SKUProduct.A, 1},
                { SKUProduct.B, 1},
                { SKUProduct.C, 1},
                { SKUProduct.D, 1}
            };

            return orderData;
        }
    }
}

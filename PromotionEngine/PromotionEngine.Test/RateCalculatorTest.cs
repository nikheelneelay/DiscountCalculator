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

        [Fact]
        public void RateCalculator_MockData_DefaultPriceForOrder()
        {
            var mockPricingService = new Mock<IPricingService>();
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.A))
                .Returns(50);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.B))
              .Returns(30);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.C))
              .Returns(20);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.D))
              .Returns(15);

            var rateCal = new RateCalculator(mockPricingService.Object);

            var totalPrice = rateCal.CalculateRate(GetMockOrderData());

            Assert.Equal(115, totalPrice);

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

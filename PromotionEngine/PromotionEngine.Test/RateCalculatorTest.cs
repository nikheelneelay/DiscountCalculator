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

            Assert.Equal(100, totalPrice);

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

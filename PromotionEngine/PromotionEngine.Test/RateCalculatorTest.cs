using PromotionEngine.Common;
using PromotionEngine.Services.Implementation;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Test
{
    public class RateCalculatorTest
    {
        [Fact]
        public void Test1()
        {
            var rateCal = new RateCalculator();

            var totalPrice = rateCal.CalculateRate(GetMockOrderData());

            Assert.Equal(100, totalPrice);

        }

        public Dictionary<SKUProducts, int> GetMockOrderData()
        {
            var orderData = new Dictionary<SKUProducts, int>
            {
                { SKUProducts.A, 1},
                { SKUProducts.B, 1},
                { SKUProducts.C, 1},
                { SKUProducts.D, 1}
            };

            return orderData;
        }
    }
}

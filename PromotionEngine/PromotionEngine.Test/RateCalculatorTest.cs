using Moq;
using PromotionEngine.Common;
using PromotionEngine.Models.DomainModels;
using PromotionEngine.Services.Implementation;
using PromotionEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PromotionEngine.Test
{
    public class RateCalculatorTest
    {
        [Fact]
        public void RateCalculator_MockData_DecimalData()
        {
            var mockPricingService = new Mock<IPricingService>();
            var mockOfferService = new Mock<IOfferService>();

            var rateCal = new RateCalculator(mockPricingService.Object, mockOfferService.Object);

            var totalPrice = rateCal.CalculateRate(GetMockOrderData());

            Assert.NotNull(totalPrice);

        }

        [Fact]
        public void RateCalculator_MockData_PricingServiceCalled()
        {
            var mockPricingService = new Mock<IPricingService>();
            var mockOfferService = new Mock<IOfferService>();

            var rateCal = new RateCalculator(mockPricingService.Object, mockOfferService.Object);

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
            var mockOfferService = new Mock<IOfferService>();
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.A))
                .Returns(50);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.B))
              .Returns(30);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.C))
              .Returns(20);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.D))
              .Returns(15);

            var rateCal = new RateCalculator(mockPricingService.Object, mockOfferService.Object);

            var totalPrice = rateCal.CalculateRate(GetMockOrderData());

            Assert.Equal(115, totalPrice);
        }

        [Fact]
        public void RateWithDiscount_Scenario1_ExpectedOutput()
        {
            var mockPricingService = new Mock<IPricingService>();
            var mockOfferService = new Mock<IOfferService>();
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.A))
                .Returns(50);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.B))
              .Returns(30);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.C))
              .Returns(20);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.D))
              .Returns(15);

            mockOfferService.Setup(repo => repo.GetExistingOffers(false))
               .Returns(GetExistingMockOffers(false));

            var rateCal = new RateCalculator(mockPricingService.Object, mockOfferService.Object);

            var totalPrice = rateCal.CalculateRateWithPromotions(GetMockOrderDataScenario1());

            Assert.Equal(100, totalPrice);
        }

        [Fact]
        public void RateWithDiscount_Scenario2_ExpectedOutput()
        {
            var mockPricingService = new Mock<IPricingService>();
            var mockOfferService = new Mock<IOfferService>();
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.A))
                .Returns(50);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.B))
              .Returns(30);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.C))
              .Returns(20);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.D))
              .Returns(15);

            mockOfferService.Setup(repo => repo.GetExistingOffers(false))
               .Returns(GetExistingMockOffers(false));

            var rateCal = new RateCalculator(mockPricingService.Object, mockOfferService.Object);

            var totalPrice = rateCal.CalculateRateWithPromotions(GetMockOrderDataScenario2());

            Assert.Equal(370, totalPrice);
        }

        [Fact]
        public void RateWithDiscount_Scenario3_ExpectedOutput()
        {
            var mockPricingService = new Mock<IPricingService>();
            var mockOfferService = new Mock<IOfferService>();
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.A))
                .Returns(50);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.B))
              .Returns(30);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.C))
              .Returns(20);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.D))
              .Returns(15);

            mockOfferService.Setup(repo => repo.GetExistingOffers(false))
               .Returns(GetExistingMockOffers(false));

            var rateCal = new RateCalculator(mockPricingService.Object, mockOfferService.Object);

            var totalPrice = rateCal.CalculateRateWithPromotions(GetMockOrderDataScenario3());

            Assert.Equal(280, totalPrice);
        }


        [Fact]
        public void RateWithDiscount_Scenario4_ExpectedOutput()
        {
            var mockPricingService = new Mock<IPricingService>();
            var mockOfferService = new Mock<IOfferService>();
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.A))
                .Returns(50);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.B))
              .Returns(30);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.C))
              .Returns(20);
            mockPricingService.Setup(repo => repo.GetDefaultRateForSKUs(SKUProduct.D))
              .Returns(15);

            mockOfferService.Setup(repo => repo.GetExistingOffers(false))
               .Returns(GetExistingMockOffers(false));

            var rateCal = new RateCalculator(mockPricingService.Object, mockOfferService.Object);

            var totalPrice = rateCal.CalculateRateWithPromotions(GetMockOrderDataScenario4());

            Assert.Equal(380, totalPrice);
        }

        public List<OfferModel> GetExistingMockOffers(bool includeInactive)
        {
            var offers = new List<OfferModel>();
            var product1 = new OfferProductModel { ProductName = SKUProduct.A, Qty = 3 };
            var product2 = new OfferProductModel { ProductName = SKUProduct.B, Qty = 2 };
            var product3 = new OfferProductModel { ProductName = SKUProduct.C, Qty = 1 };
            var product4 = new OfferProductModel { ProductName = SKUProduct.D, Qty = 1 };

            offers.Add(new OfferModel { Products = new List<OfferProductModel> { product1 }, OfferPrice = 130, Priority = 1, IsActive = true });
            offers.Add(new OfferModel { Products = new List<OfferProductModel> { product2 }, OfferPrice = 45, Priority = 1, IsActive = true });
            offers.Add(new OfferModel { Products = new List<OfferProductModel> { product3, product4 }, OfferPrice = 30, Priority = 1, IsActive = true });

            return includeInactive ? offers : offers.Where(x => x.IsActive).ToList();
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

        public Dictionary<SKUProduct, int> GetMockOrderDataScenario1()
        {
            var orderData = new Dictionary<SKUProduct, int>
            {
                { SKUProduct.A, 1},
                { SKUProduct.B, 1},
                { SKUProduct.C, 1},
                { SKUProduct.D, 0}
            };

            return orderData;
        }

        public Dictionary<SKUProduct, int> GetMockOrderDataScenario2()
        {
            var orderData = new Dictionary<SKUProduct, int>
            {
                { SKUProduct.A, 5},
                { SKUProduct.B, 5},
                { SKUProduct.C, 1},
                { SKUProduct.D, 0}
            };

            return orderData;
        }

        public Dictionary<SKUProduct, int> GetMockOrderDataScenario3()
        {
            var orderData = new Dictionary<SKUProduct, int>
            {
                { SKUProduct.A, 3},
                { SKUProduct.B, 5},
                { SKUProduct.C, 1},
                { SKUProduct.D, 1}
            };

            return orderData;
        }
        public Dictionary<SKUProduct, int> GetMockOrderDataScenario4()
        {
            var orderData = new Dictionary<SKUProduct, int>
            {
                { SKUProduct.A, 5},
                { SKUProduct.B, 5},
                { SKUProduct.C, 1},
                { SKUProduct.D, 1}
            };

            return orderData;
        }
    }
}

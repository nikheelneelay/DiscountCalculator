using Moq;
using PromotionEngine.Controllers;
using PromotionEngine.Models.ViewModels;
using PromotionEngine.Services.Interfaces;
using Xunit;

namespace PromotionEngine.Test
{
    public class PricingControllerTest
    {
        [Fact]
        public void PricingController_CalculatePrice_OkResponse()
        {
            var mockRateService = new Mock<IRateCalculatorService>();

            var pricingObj = new PricingController(mockRateService.Object);

            var data = pricingObj.OrderPrice(new OrderVM());

            Assert.Equal(0, data.Value);
        }
    }
}
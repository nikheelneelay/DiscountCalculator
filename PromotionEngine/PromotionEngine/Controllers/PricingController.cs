using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Common;
using PromotionEngine.Models.ViewModels;
using PromotionEngine.Services.Interfaces;

namespace PromotionEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        public PricingController(IRateCalculator rateCalculator)
        {
            RateCalculator = rateCalculator;
        }

        public IRateCalculator RateCalculator { get; }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> Get()
        {
            return StatusCode(StatusCodes.Status200OK, true);
        }

        [HttpPost]
        [Route("OrderPrice")]
        public ActionResult<decimal> OrderPrice(OrderVM orderInput)
        {
            var orderData = new Dictionary<SKUProduct, int>
            {
                { SKUProduct.A, orderInput.SKUAQty },
                { SKUProduct.B, orderInput.SKUBQty },
                { SKUProduct.C, orderInput.SKUCQty },
                { SKUProduct.D, orderInput.SKUDQty }
            };

            return StatusCode(StatusCodes.Status200OK, RateCalculator.CalculateRateWithPromotions(orderData));
        }
    }
}
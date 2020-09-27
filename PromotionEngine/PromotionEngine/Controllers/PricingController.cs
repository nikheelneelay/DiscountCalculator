using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Common;
using PromotionEngine.Models.ViewModels;

namespace PromotionEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> Get()
        {
            return StatusCode(StatusCodes.Status200OK, true);
        }

        [HttpPost]
        [Route("OrderPrice")]
        public async Task<ActionResult> OrderPrice(OrderVM orderInput)
        {
            var orderData = new Dictionary<SKUProducts, int>
            {
                { SKUProducts.A, orderInput.SKUAQty },
                { SKUProducts.B, orderInput.SKUBQty },
                { SKUProducts.C, orderInput.SKUCQty },
                { SKUProducts.D, orderInput.SKUDQty }
            };

            return StatusCode(StatusCodes.Status200OK, true);
        }
    }
}
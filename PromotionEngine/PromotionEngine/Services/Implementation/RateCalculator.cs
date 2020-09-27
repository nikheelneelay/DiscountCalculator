using PromotionEngine.Common;
using PromotionEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Services.Implementation
{
    public class RateCalculator : IRateCalculator
    {
        public RateCalculator(IPricingService pricingService, IOfferService offerService)
        {
            PricingService = pricingService;
            OfferService = offerService;
        }

        public IPricingService PricingService { get; }
        public IOfferService OfferService { get; }

        public decimal CalculateRate(Dictionary<SKUProduct, int> orderData)
        {
            var totalPrice = orderData.Sum(x => PricingService.GetDefaultRateForSKUs(x.Key) * x.Value);

            return totalPrice;
        }

        public decimal CalculateRateWithPromotions(Dictionary<SKUProduct, int> orderData)
        {
            var discountedTotal = GetDiscountedPrice(ref orderData);

            var undiscountedTotal = orderData.Sum(x => PricingService.GetDefaultRateForSKUs(x.Key) * x.Value);

            var totalRate = discountedTotal + undiscountedTotal;

            return totalRate;
        }

        public decimal GetDiscountedPrice(ref Dictionary<SKUProduct, int> orderData)
        {
            decimal discountedTotal = 0;
            var offers = OfferService.GetExistingOffers(false);

            foreach (var offer in offers)
            {
                var productConsidered = orderData.Where(x => offer.Products.Any(y => y.ProductName == x.Key && x.Value >= y.Qty)).ToList();

                if (productConsidered.Count != offer.Products.Count)
                {
                    // for the offer to be applicable all the products condition must match
                    continue;
                }

                if (productConsidered.Any())
                {

                    decimal noOfTimesApplicable = 0;

                    // Check how many times the discount can be applied 
                    foreach (var product in productConsidered)
                    {
                        var applicableQty = offer.Products.FirstOrDefault(x => x.ProductName == product.Key).Qty;
                        var times = Math.Floor((decimal)(product.Value / applicableQty));
                        if (noOfTimesApplicable == 0)
                        {
                            noOfTimesApplicable = times;
                        }
                        else
                        {
                            noOfTimesApplicable = times < noOfTimesApplicable ? times : noOfTimesApplicable;
                        }
                    }

                    discountedTotal += offer.OfferPrice * noOfTimesApplicable;

                    // Removed discounted quantity from orders
                    foreach (var product in productConsidered)
                    {
                        var applicableQty = offer.Products.FirstOrDefault(x => x.ProductName == product.Key).Qty;
                        orderData[product.Key] = (int)(product.Value - applicableQty * noOfTimesApplicable);
                    }
                }

            }

            return discountedTotal;
        }
    }
}

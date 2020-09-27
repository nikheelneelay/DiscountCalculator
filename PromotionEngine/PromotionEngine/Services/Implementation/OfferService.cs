using PromotionEngine.Common;
using PromotionEngine.Models.DomainModels;
using PromotionEngine.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Services.Implementation
{
    public class OfferService : IOfferService
    {
        public List<OfferModel> GetExistingOffers(bool includeInactive)
        {
            // TODO - Fetch offers from DB or configurable json
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
    }
}
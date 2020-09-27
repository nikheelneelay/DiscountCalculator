using PromotionEngine.Models.DomainModels;
using PromotionEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Services.Implementation
{
    public class OfferService : IOfferService
    {
        public List<OfferModel> GetExistingOffers(bool includeInactive)
        {
            return new List<OfferModel>();
        }
    }
}

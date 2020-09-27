using PromotionEngine.Models.DomainModels;
using System.Collections.Generic;

namespace PromotionEngine.Services.Interfaces
{
    public interface IOfferService
    {
        List<OfferModel> GetExistingOffers(bool includeInactive);
    }
}
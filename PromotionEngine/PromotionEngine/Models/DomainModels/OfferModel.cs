using System.Collections.Generic;

namespace PromotionEngine.Models.DomainModels
{
    public class OfferModel
    {
        public decimal OfferPrice { get; set; }
        public List<OfferProductModel> Products { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
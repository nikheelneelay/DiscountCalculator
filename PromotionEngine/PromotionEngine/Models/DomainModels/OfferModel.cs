using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

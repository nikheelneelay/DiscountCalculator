using PromotionEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Models.DomainModels
{
    public class OfferProductModel
    {
        public SKUProduct ProductName { get; set; }
        public int Qty { get; set; }
    }
}

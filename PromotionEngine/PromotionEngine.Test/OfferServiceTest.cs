using PromotionEngine.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PromotionEngine.Test
{
    public class OfferServiceTest
    {
        [Fact]
        public void OfferService_GetOffers_OffersExists()
        {
            var offerService = new OfferService();

            var offers = offerService.GetExistingOffers(true);

            Assert.NotNull(offers);

        }
    }
}

using PromotionEngine.Services.Implementation;
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

        [Fact]
        public void OfferService_GetOffers_OffersHasEntry()
        {
            var offerService = new OfferService();

            var offers = offerService.GetExistingOffers(true);

            Assert.True(offers.Count > 0);
        }

        [Fact]
        public void OfferService_GetActiveOffers_OffersHasEntry()
        {
            var offerService = new OfferService();

            var offers = offerService.GetExistingOffers(false);

            Assert.True(offers.Count > 0);
        }

        [Fact]
        public void OfferService_IncludeInactiveOffers_OffersHasEntry()
        {
            var offerService = new OfferService();

            var offers = offerService.GetExistingOffers(true);

            Assert.NotNull(offers);
        }
    }
}
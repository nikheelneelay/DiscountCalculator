using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Services.Implementation;
using PromotionEngine.Services.Interfaces;

namespace PromotionEngine.Infrastructure
{
    public static class Bootstrapper
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IRateCalculatorService, RateCalculatorService>();
            services.AddTransient<IPricingService, PricingService>();
            services.AddTransient<IOfferService, OfferService>();
        }
    }
}
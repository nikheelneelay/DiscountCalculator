using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Services.Implementation;
using PromotionEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Infrastructure
{
    public static class Bootstrapper
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IRateCalculator, RateCalculator>();
            services.AddTransient<IPricingService, PricingService>();
            services.AddTransient<IOfferService, OfferService>();
        }
    }
}

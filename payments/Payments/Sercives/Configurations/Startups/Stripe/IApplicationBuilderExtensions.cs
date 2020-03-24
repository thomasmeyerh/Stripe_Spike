using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sercives.Configurations.Startups.Stripe
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureStripe(
            this IApplicationBuilder applicationBuilder,
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment)
        {
            if (applicationBuilder == null)
                throw new ArgumentNullException(nameof(applicationBuilder));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (webHostEnvironment == null)
                throw new ArgumentNullException(nameof(webHostEnvironment));

            //Only thing needed to set the connection for Stripe
            StripeConfiguration.ApiKey = configuration.GetSection("Stripe").GetValue<string>("Secretkey");

            return applicationBuilder;
        }
    }
}

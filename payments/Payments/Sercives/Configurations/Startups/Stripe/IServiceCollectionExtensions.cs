using Application.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;

namespace Sercives.Configurations.Startups.Services
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureStripeServices(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            serviceCollection.AddScoped<CustomerService>();
            serviceCollection.AddScoped<PlanService>();
            serviceCollection.AddScoped<ProductService>();
            serviceCollection.AddScoped<SessionService>();
            serviceCollection.AddScoped<SubscriptionService>();
            serviceCollection.AddScoped<InvoiceService>();

            serviceCollection.Configure<StripeOptions>(opt =>
            {
                opt.PublicKey = configuration.GetSection("Stripe").GetValue<string>("PublicKey");
                opt.TaxIds = configuration.GetSection("Stripe:TaxIds").Get<List<string>>();
                opt.PaymentMethodTypes = configuration.GetSection("Stripe:PaymentMethodTypes").Get<List<string>>();

            });

            return serviceCollection;
        }
    }
}

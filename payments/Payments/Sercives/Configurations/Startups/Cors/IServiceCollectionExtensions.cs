using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sercives.Configurations.Startups.Cors
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCors(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.WithOrigins("http://localhost:63342", "http://localhost:63342"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", corsBuilder.Build());
            });

            return serviceCollection;
        }
    }
}

using Application;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sercives.Configurations.Startups.mediatR
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMediatR(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            serviceCollection.AddMediatR(typeof(Assembly));

            return serviceCollection;
        }
    }
}

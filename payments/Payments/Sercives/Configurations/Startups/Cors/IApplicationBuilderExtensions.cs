using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sercives.Configurations.Startups.Cors
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureCors(
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

            applicationBuilder.UseCors("CorsPolicy");

            return applicationBuilder;
        }
    }
}

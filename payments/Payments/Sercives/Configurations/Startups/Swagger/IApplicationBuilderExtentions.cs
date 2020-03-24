using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sercives.Configurations.Startups.Swagger
{
    public static class IApplicationBuilderExtentions
    {
        public static IApplicationBuilder ConfigureSwagger(
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            applicationBuilder.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            applicationBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payments API V1");
                c.RoutePrefix = string.Empty;
            });

            return applicationBuilder;
        }
    }
}

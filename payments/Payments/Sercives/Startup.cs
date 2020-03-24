using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sercives.Configurations.Startups.Cors;
using Sercives.Configurations.Startups.ExceptionHandler;
using Sercives.Configurations.Startups.mediatR;
using Sercives.Configurations.Startups.Services;
using Sercives.Configurations.Startups.Stripe;
using Sercives.Configurations.Startups.Swagger;

namespace Sercives
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            {
                services
                    .ConfigureCors(_configuration)
                    .ConfigureStripeServices(_configuration)
                    .ConfigureMediatR(_configuration)
                    .ConfigureSwagger(_configuration)
                    .AddControllers();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            {
                app
                    .UseCors("CorsPolicy")
                    .ConfigureStripe(_configuration, env)
                    .ConfigureSwagger(_configuration, env)
                    .UseHttpsRedirection()
                    .UseRouting()
                    .UseAuthorization()
                    .UseMiddleware(typeof(ValidationExceptionMiddleware))
                    .UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}

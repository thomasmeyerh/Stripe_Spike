using System.Collections.Generic;
using System.Configuration;
using Application;
using Application.Options;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Stripe;


[assembly: WebJobsStartup(typeof(Payments.Funtions.Startup))]

namespace Payments.Funtions
{
    public class Startup :  IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddMediatR(typeof(Assembly));
            


            StripeConfiguration.ApiKey = "sk_test_Mvw0dkozJBhnPCqhrFXBtJFH00PIfcYAVN";
        }
    }
}
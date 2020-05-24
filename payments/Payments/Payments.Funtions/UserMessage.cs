using System;
using System.Threading.Tasks;
using Application.Models;
using Application.Requests;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Payments.Funtions.Models;

namespace Payments.Funtions
{
    public  class UserMessage
    {
        private readonly IMediator _mediator;

        public UserMessage(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [FunctionName("UserMessage")]
        public  async Task RunAsync([ServiceBusTrigger("testthomasuser", "UserSubscriber", Connection = "ServiceBusConnection")]
            UserDTO dto, string label, ILogger log)
        {
            log.LogInformation($"ServiceBus topic trigger function processed user with username: {dto.Username}");
            if (label == "INSERT")
            {
                var customer = new CreateCustomerModel();
                customer.Name = $"{dto.Firstname} {dto.Lastname}";
                customer.Email = dto.Username;
                
                var request = new CreateCustomerRequest(customer);
                var result = await _mediator.Send(request);
            }
            
        }
    }
}
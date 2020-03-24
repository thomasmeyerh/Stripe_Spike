using Application.Models;
using Application.Results.Sessions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Sessions
{
    public class CreateSessionWithCustomerRequest
        : Request<CreateSessionWithCustomerModel, CreateSessionWithCustomerResult>
    {
        public CreateSessionWithCustomerRequest(CreateSessionWithCustomerModel model, string correlationId = null) 
            : base(model, correlationId)
        { }
    }
}

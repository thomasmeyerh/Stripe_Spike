using Application.Models;
using Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests
{
    public class CreateCustomerRequest
    : Request<CreateCustomerModel, CreateCustomerResult>
    {
        public CreateCustomerRequest(CreateCustomerModel model, string correlationId = null) 
            : base(model, correlationId)
        { }
    }
}

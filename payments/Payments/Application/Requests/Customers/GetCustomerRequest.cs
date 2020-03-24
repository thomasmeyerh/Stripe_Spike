using Application.Models;
using Application.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests
{
    public class GetCustomerRequest
    : Request<GetCustomerModel, GetCustomerResult>
    {
        public GetCustomerRequest(GetCustomerModel model, string correlationId = null) 
            : base(model, correlationId)
        { }
    }
}

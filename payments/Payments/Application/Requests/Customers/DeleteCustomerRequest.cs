using Application.Models;
using Application.Results.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Customers
{
    public class DeleteCustomerRequest
   : Request<DeleteCustomerModel, DeleteCustomerResult>
    {
        public DeleteCustomerRequest(DeleteCustomerModel model, string correlationId = null) 
            : base(model, correlationId)
        { }
    }
}

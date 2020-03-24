using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Results.Customers
{
    public sealed class DeleteCustomerResult
       : Result
    {
        public DeleteCustomerResult(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }
        public bool IsDeleted { get; }

    }
}

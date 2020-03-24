using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
   public class CreateSessionWithCustomerModel
        :Model
    {
        public string PlanId { get; set; }
        public string CustomerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class SubscribeCustomerToPlanModel
    {
        public string CustomerId { get; set; }
        public List<string> PlanIds { get; set; }
    }
}

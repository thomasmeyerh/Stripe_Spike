using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class GetCustomerModel
    : Model
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

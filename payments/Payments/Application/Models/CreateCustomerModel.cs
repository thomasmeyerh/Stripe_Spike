using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class CreateCustomerModel
        : Model
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

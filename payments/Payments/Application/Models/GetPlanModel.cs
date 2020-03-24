using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class GetPlanModel
        : Model
    {
        public string Id { get; set; }
        public long? Amount { get; set; }

        public ProductModel Product { get; set; }

        public class ProductModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }


}

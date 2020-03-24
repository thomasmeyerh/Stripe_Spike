using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sercives.Configurations.Startups.ExceptionHandler
{
    internal class Error
    {
        public Error()
        {
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<InnerError> Details { get; set; }

        internal class InnerError
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string Target { get; set; }
        }
    }
}

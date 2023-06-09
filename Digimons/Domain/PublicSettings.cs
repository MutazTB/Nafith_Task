using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Response
    {
        public Object Data { get; set; }

        public string ErrorMessage { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Success,
        Error,
    }
}

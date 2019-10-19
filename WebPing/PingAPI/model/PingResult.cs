using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingAPI.model
{
    public class PingResult
    {
        public string Address { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
    }
}

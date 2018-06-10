using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Driver
{
    public class Document
    {
        public string Subject { get; set; }
        public byte[] Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

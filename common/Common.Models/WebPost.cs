using System;

namespace Common.Models
{
    public class WebPost
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public Uri Url { get; set; }
    }
}
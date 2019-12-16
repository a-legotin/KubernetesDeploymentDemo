using System;

namespace Posts.RandomSource.Model
{
    public class Document
    {
        public string Subject { get; set; }
        public byte[] Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
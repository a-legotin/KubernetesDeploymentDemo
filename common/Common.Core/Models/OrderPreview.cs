using System;

namespace Common.Core.Models
{
    public class OrderPreview
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public Guid CustomerGuid { get; set; }
        public string CustomerName { get; set; }
        public Guid[] ItemGuids { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
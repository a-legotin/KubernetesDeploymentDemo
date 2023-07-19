using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Api.Database.Models
{
    public class OrderDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public Guid CustomerGuid { get; set; }

        public string CustomerName { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Guid[] ItemGuids { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
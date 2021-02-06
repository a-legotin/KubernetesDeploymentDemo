using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Api.Database.Models
{
    public class CatalogItemDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

        public CatalogCategoryDto Category { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
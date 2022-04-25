namespace WebAPIStore.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public int? Quantity { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

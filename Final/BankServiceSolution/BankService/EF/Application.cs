namespace BankService.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        public int Id { get; set; }

        public int? TypeId { get; set; }

        public int? ClientId { get; set; }

        public int? BranchId { get; set; }

        public bool? Approved { get; set; }

        public decimal? Amount { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Client Client { get; set; }

        public virtual Type Type { get; set; }
    }
}

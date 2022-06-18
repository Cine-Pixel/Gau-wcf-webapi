namespace BankService.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public int? GenderId { get; set; }

        [StringLength(11)]
        public string PersonalNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? GuarantorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Applications { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Guarantor Guarantor { get; set; }
    }
}

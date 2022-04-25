namespace FirstWcfService.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentsSubject>();
        }

        public int Id { get; set; }

        public Guid Code { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public short Credits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsSubject> StudentsSubjects { get; set; }
    }
}

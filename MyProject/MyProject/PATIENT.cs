namespace MyProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATIENT")]
    public partial class PATIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATIENT()
        {
            VISIT = new HashSet<VISIT>();
        }

        [Key]
        public int PATIENT_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string SURNAME { get; set; }

        [Required]
        [StringLength(30)]
        public string FIRSTNAME { get; set; }

        [StringLength(30)]
        public string FATHERSNAME { get; set; }

        [StringLength(1)]
        public string GENDER { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BDAY { get; set; }

        [StringLength(15)]
        public string TELEPHONE { get; set; }

        public int? ADDRESS_ID { get; set; }

        public virtual ADDRESS ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISIT { get; set; }
    }
}

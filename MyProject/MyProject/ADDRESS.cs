namespace MyProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADDRESS")]
    public partial class ADDRESS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADDRESS()
        {
            PATIENT = new HashSet<PATIENT>();
        }

        [Key]
        public int ADDRESS_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string STREET { get; set; }

        [Required]
        [StringLength(5)]
        public string HOUSE { get; set; }

        [StringLength(5)]
        public string HOUSING { get; set; }

        public int? FLAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATIENT> PATIENT { get; set; }
    }
}

namespace MyProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VISIT")]
    public partial class VISIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VISIT()
        {
        }

        [Key]
        public int VISIT_ID { get; set; }

        public int? PATIENT_ID { get; set; }
        [Required]
        public DateTime VISIT_DATE_TIME1 { get; set; }

        [StringLength(300)]
        public string COMPLAINTS { get; set; }

        [StringLength(10)]
        public string PRESSURE { get; set; }

        public decimal? HEIGHT { get; set; }

        public decimal? WEIGHT { get; set; }
        [Required]
        public bool IS_PLANNED { get; set; }
        [Required]
        public bool IS_COMPLETED { get; set; }

        public string DIAGNOSIS { get; set; }

        public string ADDITIONAL_INFORMATION { get; set; }

        public virtual PATIENT PATIENT { get; set; }

        

        public int? USER_ID { get; set; }

        public virtual USERS USERS { get; set; }
        public DateTime VISIT_DATE_TIME2 { get; set; }

    }
}

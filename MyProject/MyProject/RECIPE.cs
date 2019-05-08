namespace MyProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RECIPE")]
    public partial class RECIPE
    {
        [Key]
        public int RECIPE_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string MEDICAMENT { get; set; }

        [Required]
        [StringLength(20)]
        public string QUANTITY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EXPIRATION_DATE { get; set; }

        public int? PATIENT_ID { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}

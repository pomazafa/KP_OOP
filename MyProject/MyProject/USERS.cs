namespace MyProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS
    {
        [Key]
        public int USER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string SURNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [Required]
        [StringLength(20)]
        public string FATHERSNAME { get; set; }

        [Required]
        [StringLength(15)]
        public string LOGIN { get; set; }

        [Required]
        public int PASSWORD_HASH { get; set; }

        //дописывала сама, должно работать

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITs { get; set; }
    }
}

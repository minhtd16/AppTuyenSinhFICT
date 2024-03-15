namespace testUploadFileAjax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tinh")]
    public partial class Tinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tinh()
        {
            Huyens = new HashSet<Huyen>();
            TruongCapBas = new HashSet<TruongCapBa>();
        }

        [Key]
        public int Tinh_ID { get; set; }

        [StringLength(250)]
        public string Tinh_Ma { get; set; }

        [StringLength(250)]
        public string Tinh_Ten { get; set; }

        [StringLength(250)]
        public string Tinh_MaTen { get; set; }

        [StringLength(250)]
        public string Tinh_GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Huyen> Huyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TruongCapBa> TruongCapBas { get; set; }
    }
}

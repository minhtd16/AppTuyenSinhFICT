namespace testUploadFileAjax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuongThucXetTuyen")]
    public partial class PhuongThucXetTuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhuongThucXetTuyen()
        {
            DangKyXetTuyens = new HashSet<DangKyXetTuyen>();
        }

        [Key]
        public int Ptxt_ID { get; set; }

        [StringLength(1000)]
        public string Ptxt_TenPhuongThuc { get; set; }

        [StringLength(200)]
        public string Ptxt_GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyXetTuyen> DangKyXetTuyens { get; set; }
    }
}

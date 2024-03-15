namespace testUploadFileAjax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khoa")]
    public partial class Khoa
    {
        [Key]
        public int Khoa_ID { get; set; }

        [StringLength(500)]
        public string Khoa_TenKhoa { get; set; }

        [StringLength(500)]
        public string Khoa_DienThoai { get; set; }

        [StringLength(500)]
        public string Khoa_TruongKhoa { get; set; }

        [StringLength(500)]
        public string Khoa_GhiChu { get; set; }
    }
}

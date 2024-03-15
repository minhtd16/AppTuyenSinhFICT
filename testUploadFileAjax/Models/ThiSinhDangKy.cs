namespace testUploadFileAjax.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThiSinhDangKy")]
    public partial class ThiSinhDangKy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThiSinhDangKy()
        {
            LePhiXetTuyens = new HashSet<LePhiXetTuyen>();
            DangKyXetTuyenKhacs = new HashSet<DangKyXetTuyenKhac>();
            DangKyXetTuyenKQTQGs = new HashSet<DangKyXetTuyenKQTQG>();
            DangKyXetTuyenThangs = new HashSet<DangKyXetTuyenThang>();
        }

        [Key]
        public long ThiSinh_ID { get; set; }

        [StringLength(50)]
        public string ThiSinh_CCCD { get; set; }

        [StringLength(300)]
        public string ThiSinh_MatKhau { get; set; }

        [StringLength(300)]
        public string ThiSinh_HoLot { get; set; }

        [StringLength(300)]
        public string ThiSinh_Ten { get; set; }

        [StringLength(300)]
        public string ThiSinh_DienThoai { get; set; }

        [StringLength(300)]
        public string ThiSinh_Email { get; set; }

        [StringLength(300)]
        public string ThiSinh_NgaySinh { get; set; }

        [StringLength(300)]
        public string ThiSinh_NgayDangKy { get; set; }

        [StringLength(50)]
        public string ThiSinh_DanToc { get; set; }

        public int? ThiSinh_GioiTinh { get; set; }

        [StringLength(4)]
        public string ThiSinh_NamTotNghiep { get; set; }

        [StringLength(300)]
        public string ThiSinh_ResetCode { get; set; }

        [StringLength(300)]
        public string ThiSinh_DCNhanGiayBao { get; set; }

        [StringLength(300)]
        public string ThiSinh_HoKhauThuongTru { get; set; }

        [StringLength(300)]
        public string ThiSinh_HoKhauThuongTru_Check { get; set; }

        public int? KhuVuc_ID { get; set; }

        public int? DoiTuong_ID { get; set; }

        [StringLength(300)]
        public string ThiSinh_TruongCapBa_Ma { get; set; }

        [StringLength(300)]
        public string ThiSinh_TruongCapBa { get; set; }

        public int? DotXT_ID { get; set; }

        public int? ThiSinh_TrangThai { get; set; }

        [StringLength(200)]
        public string ThiSinh_GhiChu { get; set; }

        public int? ThiSinh_TruongCapBa_Tinh_ID { get; set; }

        [StringLength(200)]
        public string ThiSinh_Email_Temp { get; set; }

        public int? ThiSinh_HocLucLop12 { get; set; }

        public int? ThiSinh_HanhKiemLop12 { get; set; }

        public virtual DoiTuong DoiTuong { get; set; }

        public virtual DotXetTuyen DotXetTuyen { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LePhiXetTuyen> LePhiXetTuyens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyXetTuyenKhac> DangKyXetTuyenKhacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyXetTuyenKQTQG> DangKyXetTuyenKQTQGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyXetTuyenThang> DangKyXetTuyenThangs { get; set; }
    }
}

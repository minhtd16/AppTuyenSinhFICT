namespace AppTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("ThiSinh")]
    public partial class ThiSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThiSinh()
        {
            HocBas = new HashSet<HocBa>();
        }
        [Key]
        public long ThiSinh_ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        [StringLength(100)]
        [Display(Name ="Họ và tên")]
        public string ThiSinh_HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [StringLength(20)]
        public string ThiSinh_DienThoai { get; set; }
       
        [Display(Name = "Hồ sơ thí sinh")]
        [StringLength(3000)]
        public string ThiSinh_HoSoDinhKem { get; set; }

        [StringLength(500)]
        [Display(Name = "Bằng tốt nghiệp")]
        public string ThiSinh_BangTN { get; set; }

        [StringLength(500)]
        [Display(Name = "Căn cước công dân")]
        public string ThiSinh_CCCD { get; set; }

        [StringLength(50)]
        [Display(Name = "Thời gian nộp")]
        public string ThiSinh_NgayNop { get; set; }

        [Display(Name = "Trạng thái")]
        public int ThiSinh_TrangThai { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string ThiSinh_GhiChu { get; set; }

        [StringLength(200)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        public int? Nganh_ID { get; set; }

        public int? ID_Nganh1 { get; set; }

        public int? ID_Nganh2 { get; set; }

        public int? ID_Nganh3 { get; set; }
        public int ThiSinh_Check_NhapDiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocBa> HocBas { get; set; }

        public virtual Nganh Nganh { get; set; }       
    }
}

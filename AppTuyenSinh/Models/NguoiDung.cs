namespace AppTuyenSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        

        [Key]
        public int NguoiDung_ID { get; set; }

        [Display(Name = "Tên đăng nhập")]       
        [StringLength(250)]
        public string NguoiDung_UserName { get; set; }
     
        [Display(Name = "Mật khẩu")]
        [StringLength(250)]
        public string NguoiDung_Pass { get; set; }


        [Display(Name = "Họ và tên")]
        [StringLength(250)]
        public string NguoiDung_HoTen { get; set; }     

        [StringLength(250)]
        [Display(Name = "Điện thoại")]
        public string NguoiDung_DienThoai { get; set; }

        [StringLength(250)]
        [Display(Name = "Email")]
        public string NguoiDung_Email { get; set; }
      
    }
}

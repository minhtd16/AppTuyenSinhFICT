using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace testUploadFileAjax.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<AdminAccount> AdminAccounts { get; set; }
        public virtual DbSet<DangKyXetTuyen> DangKyXetTuyens { get; set; }
        public virtual DbSet<DangKyXetTuyen_DiemTS> DangKyXetTuyen_DiemTS { get; set; }
        public virtual DbSet<DoiTuong> DoiTuongs { get; set; }
        public virtual DbSet<DotXetTuyen> DotXetTuyens { get; set; }
        public virtual DbSet<Huyen> Huyens { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<KhoiNganh> KhoiNganhs { get; set; }
        public virtual DbSet<KhuVuc> KhuVucs { get; set; }
        public virtual DbSet<LePhiXetTuyen> LePhiXetTuyens { get; set; }
        public virtual DbSet<NamHoc> NamHocs { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<PhuongThucXetTuyen> PhuongThucXetTuyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThiSinhDangKy> ThiSinhDangKies { get; set; }
        public virtual DbSet<Tinh> Tinhs { get; set; }
        public virtual DbSet<ToHopMon> ToHopMons { get; set; }
        public virtual DbSet<TruongCapBa> TruongCapBas { get; set; }
        public virtual DbSet<Xa> Xas { get; set; }
        public virtual DbSet<DangKyXetTuyenKhac> DangKyXetTuyenKhacs { get; set; }
        public virtual DbSet<DangKyXetTuyenKQTQG> DangKyXetTuyenKQTQGs { get; set; }
        public virtual DbSet<DangKyXetTuyenThang> DangKyXetTuyenThangs { get; set; }
        public virtual DbSet<LienCapTHC> LienCapTHCS { get; set; }
        public virtual DbSet<LienCapTieuHoc> LienCapTieuHocs { get; set; }
        public virtual DbSet<ToHopMonNganh> ToHopMonNganhs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DotXetTuyen>()
                .HasMany(e => e.DangKyXetTuyens)
                .WithOptional(e => e.DotXetTuyen)
                .HasForeignKey(e => e.DotXT_ID);

            modelBuilder.Entity<DotXetTuyen>()
                .HasMany(e => e.ThiSinhDangKies)
                .WithOptional(e => e.DotXetTuyen)
                .HasForeignKey(e => e.DotXT_ID);

            modelBuilder.Entity<Nganh>()
                .HasMany(e => e.ToHopMonNganhs)
                .WithRequired(e => e.Nganh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ToHopMon>()
                .HasMany(e => e.ToHopMonNganhs)
                .WithRequired(e => e.ToHopMon)
                .WillCascadeOnDelete(false);
        }
    }
}

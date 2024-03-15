using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppTuyenSinh.Models;
using PagedList;
using Newtonsoft.Json;
using System.Collections;
using Telegram.Bot.Types;


namespace AppTuyenSinh.Areas.Admin.Controllers
{
    public class HocBasController : Controller
    {
        private DbConnect db = new DbConnect();


        public ActionResult tsIndex(string searchString, string currentFilter, string filteriNganh, int? page)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            else
            {
                var model = from m in db.ThiSinhs.Include(t => t.Nganh).OrderByDescending(x => x.ThiSinh_ID).Where(x => x.ThiSinh_TrangThai == 1 || x.ThiSinh_TrangThai == 2)
                            select m;
                ViewBag.totalRecodMMC = model.Where(x => x.Nganh_ID == 3).Count();
                ViewBag.totalRecodITP = model.Where(x => x.Nganh_ID == 2).Count();
                ViewBag.totalRecodIT = model.Where(x => x.Nganh_ID == 1).Count();

                #region lọc dữ liệu theo ngành
                ViewBag.filteriNganh = new SelectList(db.Nganhs.ToList(), "Nganh_ID", "Nganh_Ma_Ten");

                // thực hiện lọc nếu có 
                if (!String.IsNullOrEmpty(filteriNganh))
                {
                    //string _tenChuyenMuc = tenChuyenMuc;
                    int _iDNganh = Int32.Parse(filteriNganh);
                    model = model.Where(x => x.Nganh_ID == _iDNganh);
                }
                #endregion
                #region Tìm kiếm
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = model.Where(m => m.ThiSinh_HoTen.ToUpper().Contains(searchString.ToUpper())
                                   || m.ThiSinh_DienThoai.Contains(searchString)
                                   || m.ThiSinh_NgayNop.Contains(searchString));
                }
                #endregion
                #region Phân trang
                if (page == null) page = 1;
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                #endregion
                #region Tham số khác
                if (searchString != null) { page = 1; }
                else { searchString = currentFilter; }
                ViewBag.pageCurren = page;
                ViewBag.CurrentFilter = searchString;
                ViewBag.filteriNganhSort = filteriNganh;
                ViewBag.totalRecod = model.Count();

                #endregion
                return View(model.ToPagedList(pageNumber, pageSize));
            }
        }
        // GET: Admin/HocBas
        public ActionResult Index()
        {
            var hocBas = db.HocBas.Include(h => h.ThiSinh);
            return View(hocBas.ToList());

        }

        // GET: Admin/HocBas/Create
        public ActionResult Create(int thiSinh_ID, string currentFilter, string filteriNganh, int page)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            else
            {
                #region lấy thông tin từ trang trước, lưu lại để truyền quay lại => vị trí cũ
                ViewBag.pageCurren = page;
                ViewBag.currentFilter = currentFilter;
                ViewBag.filteriNganhSort = filteriNganh;
                ViewBag.iDCurren = thiSinh_ID;
                #endregion

                #region lấy thông tin các điểm đã nhập rồi (nếu có) của thí sinh để đưa vào bảng hiển thị điểm
                // cần cài thêm thư viện Newtonsoft.Json để conver list to json

                List<HocBa> dsDiemDaNhap = db.HocBas.Where(x => x.ThiSinh_ID == thiSinh_ID).ToList();
                string str_diem = "";
                if (dsDiemDaNhap.Count == 0) { str_diem = "Chưa có dữ liệu"; }
                else
                {
                    str_diem = JsonConvert.SerializeObject(dsDiemDaNhap); // chuyển thành chuỗi             
                }
                ViewBag.List_DiemDaNhap = str_diem;
                #endregion

                ViewBag.ThiSinh_ID = new SelectList(db.ThiSinhs.Where(x => x.ThiSinh_ID == thiSinh_ID), "ThiSinh_ID", "ThiSinh_HoTen");
                ThiSinh thiSinh_x = db.ThiSinhs.Where(x => x.ThiSinh_ID == thiSinh_ID).FirstOrDefault();

                ViewBag.ThiSinh_HoSoThiSinh = thiSinh_x.ThiSinh_HoSoDinhKem;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Update_DiemHocBa(HocBa hocbaUpdate)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            else
            {
                var thiSinh_iD = hocbaUpdate.ThiSinh_ID;
                // lưu ý cần khai báo db mới để không trùng submit
                DbConnect _db = new DbConnect();
                var ts_ud_c_nhapdiem = _db.ThiSinhs.Find(thiSinh_iD);
                ts_ud_c_nhapdiem.ThiSinh_Check_NhapDiem += 1;
                _db.SaveChanges();

                db.HocBas.Add(hocbaUpdate);
                db.SaveChanges();
                var model = db.HocBas.Where(x => x.ThiSinh_ID == thiSinh_iD);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Admin/HocBas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/HocBas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

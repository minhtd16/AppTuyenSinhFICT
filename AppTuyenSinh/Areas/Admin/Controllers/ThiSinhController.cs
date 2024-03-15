using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AppTuyenSinh.Models;
using PagedList;

namespace AppTuyenSinh.Areas.Admin.Controllers
{

    public class ThiSinhController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Admin/ThiSinh
        public ActionResult Index(string searchString, string currentFilter, int? page, string filteriNganh)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Logins");
            }
            else
            {
                var model = from m in db.ThiSinhs.Include(t => t.Nganh).OrderByDescending(x => x.ThiSinh_ID)
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

        public JsonResult GetByID(long ID)
        {
            ThiSinh model = db.ThiSinhs.Where(x => x.ThiSinh_ID == ID).FirstOrDefault();
            return Json(new
            {
                nganh_ID = model.Nganh_ID,
                thiSinh_ID = model.ThiSinh_ID,
                thiSinh_HoTen = model.ThiSinh_HoTen,
                thiSinh_DienThoai = model.ThiSinh_DienThoai,
                thiSinh_HoSoDinhKem = model.ThiSinh_HoSoDinhKem,
                thiSinh_BangTN = model.ThiSinh_BangTN,
                thiSinh_CCCD = model.ThiSinh_CCCD,
                thiSinh_NgayNop = model.ThiSinh_NgayNop,
                thiSinh_TrangThai = model.ThiSinh_TrangThai,
                thiSinh_GhiChu = model.ThiSinh_GhiChu,
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update_HoSoThiSinh(ThiSinh thiSinh)
        {
            ThiSinh model1 = db.ThiSinhs.Where(x => x.ThiSinh_ID == thiSinh.ThiSinh_ID).FirstOrDefault();
            model1.ThiSinh_GhiChu = thiSinh.ThiSinh_GhiChu;
            model1.ThiSinh_TrangThai = thiSinh.ThiSinh_TrangThai;
            db.SaveChanges();
            //RedirectToAction("Index", "ThiSinh");
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #region test thử
        public ActionResult tsDefault()
        {
            return View();
        }
        public JsonResult tsListAll()
        {
            List<ThiSinh> model = db.ThiSinhs.Include(t => t.Nganh).OrderByDescending(x => x.ThiSinh_ID).ToList();
            List<ThiSinhShowAjax> tsLitstAll = new List<ThiSinhShowAjax>();
            foreach (ThiSinh item in model)
            {
                ThiSinhShowAjax _ts = new ThiSinhShowAjax();
                #region xử lý hiển thị các file hồ sơ
                string[] str_file_hoso = item.ThiSinh_HoSoDinhKem.Split(new Char[] { '#' });
                int index_str_hoso = 0;
                string str_file_hoso_show = "";

                foreach (string _item in str_file_hoso)
                {
                    index_str_hoso++;
                    if (_item.Trim().Length > 0)
                    {
                        string str_url = "https://localhost:44341/" + _item;
                        str_file_hoso_show += "<a href =\"" + str_url + "\"target =\"_blank\" style=\"text-decoration:none\" title=\"bấm chuột để xem thông tin\">Tệp " + index_str_hoso + " </a>";
                    }
                }
                #endregion
                #region hiển thị các file bằng tốt nghiệp
                string str_file_bangtn_show = "";
                if (!String.IsNullOrEmpty(item.ThiSinh_BangTN))
                {
                    string[] arr_str_file_bangtn = item.ThiSinh_BangTN.Split(new Char[] { '#' });
                    int index_str_bangtn = 0;
                    foreach (string _item in arr_str_file_bangtn)
                    {
                        index_str_bangtn++;
                        if (_item.Trim().Length > 0)
                        {
                            string str_url = "https://localhost:44341/" + _item;
                            str_file_bangtn_show += "<a href =\"" + str_url + "\"target =\"_blank\" style=\"text-decoration:none\" title=\"bấm chuột để xem thông tin\">Tệp " + index_str_bangtn + " </a>";
                        }
                    }
                }

                #endregion
                #region hiển thị các file thẻ căn cước
                string str_file_the_show = "";
                if (!String.IsNullOrEmpty(item.ThiSinh_CCCD))
                {
                    string[] arr_str_file_the = item.ThiSinh_CCCD.Split(new Char[] { '#' });
                    int index_str_the = 0;
                    foreach (string _item in arr_str_file_the)
                    {
                        index_str_the++;
                        if (_item.Trim().Length > 0)
                        {
                            string str_url = "https://localhost:44341/" + _item;
                            str_file_the_show += "<a href =\"" + str_url + "\"target =\"_blank\" style=\"text-decoration:none\" title=\"bấm chuột để xem thông tin\">Tệp " + index_str_the + " </a>";
                        }
                    }
                }

                #endregion

                _ts.ts_TenNganh = item.Nganh.Nganh_Ten;
                _ts.ts_ID = item.ThiSinh_ID.ToString();
                _ts.ts_HoTen = item.ThiSinh_HoTen;
                _ts.ts_DienThoai = item.ThiSinh_DienThoai;
                _ts.ts_HoSoDinhKem = str_file_hoso_show;
                _ts.ts_BangTN = str_file_bangtn_show;
                _ts.ts_CCCD = str_file_the_show;
                _ts.ts_NgayNop = item.ThiSinh_NgayNop;
                _ts.ts_TrangThai = item.ThiSinh_TrangThai.ToString();
                _ts.ts_GhiChu = item.ThiSinh_GhiChu;
                tsLitstAll.Add(_ts);
            }
            return this.Json(tsLitstAll.ToList(), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
    #region phục vụ test thử
    public class ThiSinhShowAjax
    {
        public string ts_TenNganh { get; set; }
        public string ts_ID { get; set; }
        public string ts_HoTen { get; set; }
        public string ts_DienThoai { get; set; }
        public string ts_HoSoDinhKem { get; set; }
        public string ts_BangTN { get; set; }
        public string ts_CCCD { get; set; }
        public string ts_NgayNop { get; set; }
        public string ts_TrangThai { get; set; }
        public string ts_GhiChu { get; set; }

    }
    #endregion
}

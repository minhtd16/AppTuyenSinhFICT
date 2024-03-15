using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AppTuyenSinh.Models;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AppTuyenSinh.Controllers
{
    public class ThiSinhsController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: ThiSinhs/Create
        public ActionResult Index()
        {
            ViewBag.Nganh_ID = new SelectList(db.Nganhs, "Nganh_ID", "Nganh_Ma_Ten");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ThiSinh thiSinh, HttpPostedFileBase[] files)
        {
            TempData["Result"] = "";
            ViewBag.Nganh_ID = new SelectList(db.Nganhs, "Nganh_ID", "Nganh_Ma_Ten", thiSinh.Nganh_ID);

            var fileCCCD = Request.Files["fileCCCD"];
            string FileCCCD_Ext = Path.GetExtension(fileCCCD.FileName).ToUpper();
            var fileTN = Request.Files["fileTN"];
            string FileBTN_Ext = Path.GetExtension(fileCCCD.FileName).ToUpper();

            //Kiểm tra điều kiện
            thiSinh.ThiSinh_HoSoDinhKem = "";
            thiSinh.ID_Nganh1 = thiSinh.ID_Nganh2 = thiSinh.ID_Nganh3 = 0;
            if (ModelState.IsValid)
            {   //Duyệt các file được upload lên server

                #region upload Căn cước công dân
                if (fileCCCD != null && fileCCCD.ContentLength > 0)
                {
                    var InputFileName = Path.GetFileName(fileCCCD.FileName);
                    InputFileName = thiSinh.ThiSinh_DienThoai + "_" + DateTime.Now.ToFileTime() + "_" + InputFileName;
                    var urlFile = Server.MapPath("~/UploadedCCCD/") + InputFileName;
                    fileCCCD.SaveAs(urlFile);
                    thiSinh.ThiSinh_CCCD = "UploadedCCCD/" + InputFileName; ;
                    ViewBag.UploadStatus = InputFileName + " file uploaded successfully";
                }
                #endregion
                #region upload bằng tốt nghiệp

                if (fileTN != null && fileTN.ContentLength > 0)
                {
                    var InputFileName = Path.GetFileName(fileTN.FileName);
                    InputFileName = thiSinh.ThiSinh_DienThoai + "_" + DateTime.Now.ToFileTime() + "_" + InputFileName;
                    var urlFile = Server.MapPath("~/UploadedBangTN/") + InputFileName;
                    fileTN.SaveAs(urlFile);
                    thiSinh.ThiSinh_BangTN = "UploadedBangTN/" + InputFileName;
                    ViewBag.UploadStatus = InputFileName + " file uploaded successfully";
                }
                #endregion
                #region upload nhiều file học bạ

                foreach (HttpPostedFileBase file in files)
                {
                    string file_check_Ext = Path.GetExtension(file.FileName).ToUpper();
                    //Kiểm tra tập tin có sẵn để lưu.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        InputFileName = thiSinh.ThiSinh_DienThoai + "_" + DateTime.Now.ToFileTime() + "_" + InputFileName;
                        var urlFile = Server.MapPath("~/UploadedFiles/") + InputFileName;
                        // Lưu file vào thư mục trên server  
                        file.SaveAs(urlFile);
                        // lấy đường dẫn các file
                        thiSinh.ThiSinh_HoSoDinhKem += "UploadedFiles/" + InputFileName + "#";
                        // Hiển thị thông báo tổng số tệp đã lưu trên server.  
                        //ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully";
                        TempData["Result"] = "THANHCONG";
                    }
                    else
                    {
                        TempData["Result"] = "THATBAI";
                    }

                }
                #endregion
                #region Lưu dữ liệu vào database
                // lưu vào cơ sở dữ liệu thông tin thí sinh 
                DateTime _date_now = DateTime.Now;
                thiSinh.ThiSinh_NgayNop = _date_now.ToString("yyyy/MM/dd HH:mm:ss");
                thiSinh.ThiSinh_TrangThai = 4;
                thiSinh.ThiSinh_GhiChu = "Chưa kiểm tra hồ sơ";
                thiSinh.ThiSinh_Check_NhapDiem = 0;
               
                db.ThiSinhs.Add(thiSinh);
                db.SaveChanges();
                #endregion
                #region Push thông báo đến telegram
                // Push thông báo đến telegram
                string ten_nganh_selected = db.Nganhs.FirstOrDefault(x => x.Nganh_ID == thiSinh.Nganh_ID).Nganh_Ten;

                var botClient = new TelegramBotClient("6141873597:AAHIe4Ep8tqArRzzRSizlDV8ZdpsdHbINNk");
                var chatId = "-878395550";
                Message message = await botClient.SendTextMessageAsync(
                 chatId: chatId, text: $"Thí sinh {thiSinh.ThiSinh_HoTen} - SĐT: {thiSinh.ThiSinh_DienThoai} đã nộp hồ sơ ngành {ten_nganh_selected}. Vui lòng kiểm tra thông tin.", parseMode: ParseMode.Html);
                #endregion
                // gọi lại form và hiển thị toats thông báo nộp học bạ thành công
                return RedirectToAction("Index");
            }
            return View(thiSinh);
        }
        bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".pdf":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

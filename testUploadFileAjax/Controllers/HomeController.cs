using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testUploadFileAjax.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult test()
        {
            return View();
        }

        public ActionResult uploadfile_multi()
        {

            return View();
        }
        [HttpPost]
        public JsonResult UploadFile_Multi()
        {
            int so_file_hb = int.Parse(Request["so_file_hb"].ToString());
            int so_file_cccd = int.Parse(Request["so_file_cccd"].ToString());
            int so_file_btn = int.Parse(Request["so_file_btn"].ToString());
            int so_file_gtut = int.Parse(Request["so_file_gtut"].ToString());


            HttpFileCollectionBase files = Request.Files;
            int j = 0;
            string Dkxt_MinhChung_HB = "";
            string Dkxt_MinhChung_CCCD = "";
            string Dkxt_MinhChung_Bang = "";         
            string Dkxt_MinhChung_UuTien = "";

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                string fname;
                // Checking for Internet Explorer      
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                }
                // lấy chuỗi lưu vào csdl
                if (i < so_file_hb)
                {
                    Dkxt_MinhChung_HB += "#/Uploads/" + fname;
                }
                if (i >= so_file_hb && i < so_file_hb + so_file_cccd)
                {
                    Dkxt_MinhChung_CCCD += "#/Uploads/" + fname;
                }

                if (i > so_file_hb + so_file_cccd  && i < so_file_btn + so_file_hb + so_file_cccd)
                {
                    Dkxt_MinhChung_Bang += "#/Uploads/" + fname;
                }
                if (i > so_file_btn + so_file_hb + so_file_cccd && i < so_file_gtut + so_file_btn + so_file_hb + so_file_cccd)
                {
                    Dkxt_MinhChung_UuTien += "#/Uploads/" + fname;
                }

                // Get the complete folder path and store the file inside it.      
                fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);               
                file.SaveAs(fname);              

            }
            return Json(new
            {
                Dkxt_MinhChung_HB,
                Dkxt_MinhChung_CCCD,
                Dkxt_MinhChung_Bang,
                Dkxt_MinhChung_UuTien,

            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult uploadfile()
        {

            return View();
        }

        public ActionResult UploadFiles()
        {
            string uname = Request["uploadername"];
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                string fname;
                // Checking for Internet Explorer      
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                }
                // Get the complete folder path and store the file inside it.      
                fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                file.SaveAs(fname);
            }
            return Json("Hi, " + uname + ". Your files uploaded successfully", JsonRequestBehavior.AllowGet);
        }
    }
}

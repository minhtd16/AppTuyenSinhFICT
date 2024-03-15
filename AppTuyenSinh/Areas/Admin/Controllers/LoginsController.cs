using AppTuyenSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AppTuyenSinh.Areas.Admin.Controllers
{
    public class LoginsController : Controller
    {
        private DbConnect db = new DbConnect();
        public ActionResult Index()
        {
            var str = CreateMD5("fict", "fict@123");
            ViewBag.str = str;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        // POST: Admin/Logins
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string nguoidung_username, string nguoidung_pass)
        {
            Session["userID"] = null;
            ViewBag.LoginErrorMessager = "";

            string _pass = CreateMD5(nguoidung_username, nguoidung_pass);          
            var userLoginDetails = db.NguoiDungs.Where(x => x.NguoiDung_UserName == nguoidung_username && x.NguoiDung_Pass == _pass).FirstOrDefault();

            if (userLoginDetails != null)
            {
                Session["userID"] = userLoginDetails.NguoiDung_ID;
                return RedirectToAction("Index", "ThiSinh");
                
            }
            else
            {
                ViewBag.LoginErrorMessager = "Sai tên đăng nhập hoặc mật khẩu";
                return View();
            }           
        }

        //Logout
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();//remove session
            return RedirectToAction("Login", "LogIn");
        }


        public string CreateMD5(string input_user, string input_pass)
        {
            string input = input_user.Trim() + input_pass.Trim();
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }          
            return sb.ToString();
        }
    }
}
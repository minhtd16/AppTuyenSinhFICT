using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTuyenSinh.Models;

namespace AppTuyenSinh.Areas.Admin.Controllers
{
    public class KetQuasController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Admin/KetQuas
        public ActionResult Index()
        {
            var ketQuas = db.KetQuas.Include(k => k.HocBa);
            return View(ketQuas.ToList());
        }

        // GET: Admin/KetQuas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // GET: Admin/KetQuas/Create
        public ActionResult Create()
        {
            ViewBag.HocBa_ID = new SelectList(db.HocBas, "HocBa_ID", "HocBa_ID");
            return View();
        }

        // POST: Admin/KetQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KetQua_ID,KetQua_DiemTH1,KetQua_DiemTH2,KetQua_DiemTH3,KetQua_DiemTH4,TrangThai,HocBa_ID")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.KetQuas.Add(ketQua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HocBa_ID = new SelectList(db.HocBas, "HocBa_ID", "HocBa_ID", ketQua.HocBa_ID);
            return View(ketQua);
        }

        // GET: Admin/KetQuas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            ViewBag.HocBa_ID = new SelectList(db.HocBas, "HocBa_ID", "HocBa_ID", ketQua.HocBa_ID);
            return View(ketQua);
        }

        // POST: Admin/KetQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KetQua_ID,KetQua_DiemTH1,KetQua_DiemTH2,KetQua_DiemTH3,KetQua_DiemTH4,TrangThai,HocBa_ID")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HocBa_ID = new SelectList(db.HocBas, "HocBa_ID", "HocBa_ID", ketQua.HocBa_ID);
            return View(ketQua);
        }

        // GET: Admin/KetQuas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KetQua ketQua = db.KetQuas.Find(id);
            if (ketQua == null)
            {
                return HttpNotFound();
            }
            return View(ketQua);
        }

        // POST: Admin/KetQuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KetQua ketQua = db.KetQuas.Find(id);
            db.KetQuas.Remove(ketQua);
            db.SaveChanges();
            return RedirectToAction("Index");
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

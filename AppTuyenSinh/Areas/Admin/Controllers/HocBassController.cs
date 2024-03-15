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
    public class HocBassController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Admin/HocBas
        public ActionResult Index()
        {
            var hocBas = db.HocBas.Include(h => h.ThiSinh);
            return View(hocBas.ToList());
        }

        // GET: Admin/HocBas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocBa hocBa = db.HocBas.Find(id);
            if (hocBa == null)
            {
                return HttpNotFound();
            }
            return View(hocBa);
        }

        // GET: Admin/HocBas/Create
        public ActionResult Create()
        {
            ViewBag.ThiSinh_ID = new SelectList(db.ThiSinhs, "ThiSinh_ID", "ThiSinh_HoTen");
            return View();
        }

        // POST: Admin/HocBas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HocBa_ID,HocBa_HocKi,HocBa_Lop,HocBa_DiemToan,HocBa_DiemLi,HocBa_DiemHoa,HocBa_DiemVan,HocBa_DiemAnh,HocBa_DiemGDCD,HocBa_DiemSinh,HocBa_DiemSu,HocBa_DiemDia,HocBa_HocLuc,ThiSinh_ID")] HocBa hocBa)
        {
            if (ModelState.IsValid)
            {
                db.HocBas.Add(hocBa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThiSinh_ID = new SelectList(db.ThiSinhs, "ThiSinh_ID", "ThiSinh_HoTen", hocBa.ThiSinh_ID);
            return View(hocBa);
        }

        // GET: Admin/HocBas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocBa hocBa = db.HocBas.Find(id);
            if (hocBa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThiSinh_ID = new SelectList(db.ThiSinhs, "ThiSinh_ID", "ThiSinh_HoTen", hocBa.ThiSinh_ID);
            return View(hocBa);
        }

        // POST: Admin/HocBas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HocBa_ID,HocBa_HocKi,HocBa_Lop,HocBa_DiemToan,HocBa_DiemLi,HocBa_DiemHoa,HocBa_DiemVan,HocBa_DiemAnh,HocBa_DiemGDCD,HocBa_DiemSinh,HocBa_DiemSu,HocBa_DiemDia,HocBa_HocLuc,ThiSinh_ID")] HocBa hocBa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocBa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThiSinh_ID = new SelectList(db.ThiSinhs, "ThiSinh_ID", "ThiSinh_HoTen", hocBa.ThiSinh_ID);
            return View(hocBa);
        }

        // GET: Admin/HocBas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocBa hocBa = db.HocBas.Find(id);
            if (hocBa == null)
            {
                return HttpNotFound();
            }
            return View(hocBa);
        }

        // POST: Admin/HocBas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            HocBa hocBa = db.HocBas.Find(id);
            db.HocBas.Remove(hocBa);
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

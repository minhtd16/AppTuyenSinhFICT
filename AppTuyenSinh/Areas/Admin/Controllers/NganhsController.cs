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
    public class NganhsController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Admin/Nganhs
        public ActionResult Index()
        {
            var nganhs = db.Nganhs.Include(n => n.DonVi);
            return View(nganhs.ToList());
        }

        // GET: Admin/Nganhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganh nganh = db.Nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            return View(nganh);
        }

        // GET: Admin/Nganhs/Create
        public ActionResult Create()
        {
            ViewBag.DonVi_ID = new SelectList(db.DonVis, "DonVi_ID", "DonVi_Ma");
            return View();
        }

        // POST: Admin/Nganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nganh_ID,Nganh_Ma,Nganh_Ten,Nganh_Ma_Ten,Nganh_ToHopXT,Nganh_SP,DonVi_ID")] Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                db.Nganhs.Add(nganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonVi_ID = new SelectList(db.DonVis, "DonVi_ID", "DonVi_Ma", nganh.DonVi_ID);
            return View(nganh);
        }

        // GET: Admin/Nganhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganh nganh = db.Nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonVi_ID = new SelectList(db.DonVis, "DonVi_ID", "DonVi_Ma", nganh.DonVi_ID);
            return View(nganh);
        }

        // POST: Admin/Nganhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nganh_ID,Nganh_Ma,Nganh_Ten,Nganh_Ma_Ten,Nganh_ToHopXT,Nganh_SP,DonVi_ID")] Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonVi_ID = new SelectList(db.DonVis, "DonVi_ID", "DonVi_Ma", nganh.DonVi_ID);
            return View(nganh);
        }

        // GET: Admin/Nganhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nganh nganh = db.Nganhs.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            return View(nganh);
        }

        // POST: Admin/Nganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nganh nganh = db.Nganhs.Find(id);
            db.Nganhs.Remove(nganh);
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

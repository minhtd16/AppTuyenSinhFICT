﻿using System;
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
    public class DonVisController : Controller
    {
        private DbConnect db = new DbConnect();

        // GET: Admin/DonVis
        public ActionResult Index()
        {
            return View(db.DonVis.ToList());
        }

        // GET: Admin/DonVis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonVi donVi = db.DonVis.Find(id);
            if (donVi == null)
            {
                return HttpNotFound();
            }
            return View(donVi);
        }

        // GET: Admin/DonVis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonVis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonVi_ID,DonVi_Ma,DonVi_Ten")] DonVi donVi)
        {
            if (ModelState.IsValid)
            {
                db.DonVis.Add(donVi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donVi);
        }

        // GET: Admin/DonVis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonVi donVi = db.DonVis.Find(id);
            if (donVi == null)
            {
                return HttpNotFound();
            }
            return View(donVi);
        }

        // POST: Admin/DonVis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonVi_ID,DonVi_Ma,DonVi_Ten")] DonVi donVi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donVi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donVi);
        }

        // GET: Admin/DonVis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonVi donVi = db.DonVis.Find(id);
            if (donVi == null)
            {
                return HttpNotFound();
            }
            return View(donVi);
        }

        // POST: Admin/DonVis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonVi donVi = db.DonVis.Find(id);
            db.DonVis.Remove(donVi);
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

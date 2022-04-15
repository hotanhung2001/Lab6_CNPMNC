using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class THANHVIENsController : Controller
    {
        private Demo_Lab5Entities db = new Demo_Lab5Entities();

        // GET: THANHVIENs
        public ActionResult Index()
        {
            var tHANHVIENs = db.THANHVIENs.Include(t => t.YEUTHICH);
            return View(tHANHVIENs.ToList());
        }

        // GET: THANHVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // GET: THANHVIENs/Create
        public ActionResult Create()
        {
            ViewBag.IDTV = new SelectList(db.YEUTHICHes, "IDYT", "IDYT");
            return View();
        }

        // POST: THANHVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTV,HovaTen,NgaySinh,email,gender,NgayThamGia,SDT")] THANHVIEN tHANHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.THANHVIENs.Add(tHANHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTV = new SelectList(db.YEUTHICHes, "IDYT", "IDYT", tHANHVIEN.IDTV);
            return View(tHANHVIEN);
        }

        // GET: THANHVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTV = new SelectList(db.YEUTHICHes, "IDYT", "IDYT", tHANHVIEN.IDTV);
            return View(tHANHVIEN);
        }

        // POST: THANHVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTV,HovaTen,NgaySinh,email,gender,NgayThamGia,SDT")] THANHVIEN tHANHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHANHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTV = new SelectList(db.YEUTHICHes, "IDYT", "IDYT", tHANHVIEN.IDTV);
            return View(tHANHVIEN);
        }

        // GET: THANHVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            if (tHANHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tHANHVIEN);
        }

        // POST: THANHVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THANHVIEN tHANHVIEN = db.THANHVIENs.Find(id);
            db.THANHVIENs.Remove(tHANHVIEN);
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

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
    public class YEUTHICHesController : Controller
    {
        private Demo_Lab5Entities db = new Demo_Lab5Entities();

        // GET: YEUTHICHes
        public ActionResult Index()
        {
            var yEUTHICHes = db.YEUTHICHes.Include(y => y.THANHVIEN);
            return View(yEUTHICHes.ToList());
        }

        // GET: YEUTHICHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YEUTHICH yEUTHICH = db.YEUTHICHes.Find(id);
            if (yEUTHICH == null)
            {
                return HttpNotFound();
            }
            return View(yEUTHICH);
        }

        // GET: YEUTHICHes/Create
        public ActionResult Create()
        {
            ViewBag.IDYT = new SelectList(db.THANHVIENs, "IDTV", "HovaTen");
            return View();
        }

        // POST: YEUTHICHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDYT,IDTV")] YEUTHICH yEUTHICH)
        {
            if (ModelState.IsValid)
            {
                db.YEUTHICHes.Add(yEUTHICH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDYT = new SelectList(db.THANHVIENs, "IDTV", "HovaTen", yEUTHICH.IDYT);
            return View(yEUTHICH);
        }

        // GET: YEUTHICHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YEUTHICH yEUTHICH = db.YEUTHICHes.Find(id);
            if (yEUTHICH == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDYT = new SelectList(db.THANHVIENs, "IDTV", "HovaTen", yEUTHICH.IDYT);
            return View(yEUTHICH);
        }

        // POST: YEUTHICHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDYT,IDTV")] YEUTHICH yEUTHICH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yEUTHICH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDYT = new SelectList(db.THANHVIENs, "IDTV", "HovaTen", yEUTHICH.IDYT);
            return View(yEUTHICH);
        }

        // GET: YEUTHICHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YEUTHICH yEUTHICH = db.YEUTHICHes.Find(id);
            if (yEUTHICH == null)
            {
                return HttpNotFound();
            }
            return View(yEUTHICH);
        }

        // POST: YEUTHICHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YEUTHICH yEUTHICH = db.YEUTHICHes.Find(id);
            db.YEUTHICHes.Remove(yEUTHICH);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ErrorHandle.Models;

namespace ErrorHandle.Controllers

{
    [HandleError(View = "Error")]

    public class CorStdsController : Controller
    {
        private Entities db = new Entities();

        // GET: CorStds
        public ActionResult Index()
        {
            var corStds = db.CorStds.Include(c => c.Course).Include(c => c.MVCStudent);
            return View(corStds.ToList());
        }

        // GET: CorStds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorStd corStd = db.CorStds.Find(id);
            if (corStd == null)
            {
                return HttpNotFound();
            }
            return View(corStd);
        }

        // GET: CorStds/Create
        public ActionResult Create()
        {
            ViewBag.CorID = new SelectList(db.Courses, "CourseID", "CName");
            ViewBag.CorID = new SelectList(db.MVCStudents, "StudentID", "Name");
            return View();
        }

        // POST: CorStds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CorID,StdID,vv")] CorStd corStd)
        {
            if (ModelState.IsValid)
            {
                db.CorStds.Add(corStd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CorID = new SelectList(db.Courses, "CourseID", "CName", corStd.CorID);
            ViewBag.CorID = new SelectList(db.MVCStudents, "StudentID", "Name", corStd.CorID);
            return View(corStd);
        }

        // GET: CorStds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorStd corStd = db.CorStds.Find(id);
            if (corStd == null)
            {
                return HttpNotFound();
            }
            ViewBag.CorID = new SelectList(db.Courses, "CourseID", "CName", corStd.CorID);
            ViewBag.CorID = new SelectList(db.MVCStudents, "StudentID", "Name", corStd.CorID);
            return View(corStd);
        }

        // POST: CorStds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CorID,StdID,vv")] CorStd corStd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corStd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CorID = new SelectList(db.Courses, "CourseID", "CName", corStd.CorID);
            ViewBag.CorID = new SelectList(db.MVCStudents, "StudentID", "Name", corStd.CorID);
            return View(corStd);
        }

        // GET: CorStds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorStd corStd = db.CorStds.Find(id);
            if (corStd == null)
            {
                return HttpNotFound();
            }
            return View(corStd);
        }

        // POST: CorStds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CorStd corStd = db.CorStds.Find(id);
            db.CorStds.Remove(corStd);
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

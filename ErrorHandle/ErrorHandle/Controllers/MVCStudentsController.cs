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
    [HandleError(View = "Error2")]

    public class MVCStudentsController : Controller
    {
        private Entities db = new Entities();

        // GET: MVCStudents
        public ActionResult Index()
        {
            return View(db.MVCStudents.ToList());
        }

        // GET: MVCStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCStudent mVCStudent = db.MVCStudents.Find(id);
            if (mVCStudent == null)
            {
                return HttpNotFound();
            }
            return View(mVCStudent);
        }

        // GET: MVCStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVCStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Name,Email")] MVCStudent mVCStudent)
        {
            if (ModelState.IsValid)
            {
                db.MVCStudents.Add(mVCStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mVCStudent);
        }

        // GET: MVCStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCStudent mVCStudent = db.MVCStudents.Find(id);
            if (mVCStudent == null)
            {
                return HttpNotFound();
            }
            return View(mVCStudent);
        }

        // POST: MVCStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Name,Email")] MVCStudent mVCStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mVCStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mVCStudent);
        }

        // GET: MVCStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCStudent mVCStudent = db.MVCStudents.Find(id);
            if (mVCStudent == null)
            {
                return HttpNotFound();
            }
            return View(mVCStudent);
        }

        // POST: MVCStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MVCStudent mVCStudent = db.MVCStudents.Find(id);
            db.MVCStudents.Remove(mVCStudent);
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

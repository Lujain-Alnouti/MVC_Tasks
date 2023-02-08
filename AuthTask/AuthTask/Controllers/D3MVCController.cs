using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthTask.Models;

namespace AuthTask.Controllers
{
    [Authorize]
    public class D3MVCController : Controller
    {
        private AuthEntities db = new AuthEntities();

        // GET: D3MVC
        public ActionResult Index()
        {
            return View(db.D3MVC.ToList());
        }

        // GET: D3MVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            D3MVC d3MVC = db.D3MVC.Find(id);
            if (d3MVC == null)
            {
                return HttpNotFound();
            }
            return View(d3MVC);
        }

        // GET: D3MVC/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: D3MVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] D3MVC d3MVC)
        {
            if (ModelState.IsValid)
            {
                db.D3MVC.Add(d3MVC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(d3MVC);
        }

        // GET: D3MVC/Edit/5
        [Authorize(Roles ="Admin")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            D3MVC d3MVC = db.D3MVC.Find(id);
            if (d3MVC == null)
            {
                return HttpNotFound();
            }
            return View(d3MVC);
        }

        // POST: D3MVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] D3MVC d3MVC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(d3MVC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d3MVC);
        }

        // GET: D3MVC/Delete/5
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            D3MVC d3MVC = db.D3MVC.Find(id);
            if (d3MVC == null)
            {
                return HttpNotFound();
            }
            return View(d3MVC);
        }

        // POST: D3MVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            D3MVC d3MVC = db.D3MVC.Find(id);
            db.D3MVC.Remove(d3MVC);
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

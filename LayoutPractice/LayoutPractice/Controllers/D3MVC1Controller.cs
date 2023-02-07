using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LayoutPractice.Models;

namespace LayoutPractice.Controllers
{
    public class D3MVC1Controller : Controller
    {
        private EntitiesTemp db = new EntitiesTemp();

        // GET: D3MVC1
        public ActionResult Index()
        {
            return View(db.D3MVC.ToList());
        }

        // GET: D3MVC1/Details/5
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

        // GET: D3MVC1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: D3MVC1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] D3MVC d3MVC, HttpPostedFileBase image, HttpPostedFileBase cv)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/Images/") + image.FileName;
                    image.SaveAs(path);
                    d3MVC.Image = image.FileName;
                }

                if (cv != null)
                {
                    //string fileName = Path.GetFileName(cv.FileName);
                    string path = Server.MapPath("~/CVs/") + cv.FileName;
                    cv.SaveAs(path);
                    d3MVC.CV = cv.FileName;
                }
                db.D3MVC.Add(d3MVC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(d3MVC);
        }

        // GET: D3MVC1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            D3MVC d3MVC = db.D3MVC.Find(id);
            Session["IMG"] = d3MVC.Image;
            Session["CV"] = d3MVC.CV;
            if (d3MVC == null)
            {
                return HttpNotFound();
            }
            return View(d3MVC);
        }

        // POST: D3MVC1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender,Image,CV")] D3MVC d3MVC)
        {
            d3MVC.Image = Session["IMG"].ToString();
            d3MVC.CV = Session["CV"].ToString();
            if (ModelState.IsValid)
            {
                db.Entry(d3MVC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d3MVC);
        }

        // GET: D3MVC1/Delete/5
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

        // POST: D3MVC1/Delete/5
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

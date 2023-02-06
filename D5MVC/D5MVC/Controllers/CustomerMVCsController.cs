using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using D5MVC.Models;

namespace D5MVC.Controllers
{
    public class CustomerMVCsController : Controller
    {
        private Entities db = new Entities();

        // GET: CustomerMVCs
        public ActionResult Index()
        {
            return View(db.CustomerMVCs.ToList());
        }
        public ActionResult LastOrder()
        {
            var Last = db.OrderDas.OrderByDescending(a => a.OrderData).First();
            return PartialView("_LastOrder", Last);
        }

        // GET: CustomerMVCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerMVC customerMVC = db.CustomerMVCs.Find(id);
            if (customerMVC == null)
            {
                return HttpNotFound();
            }
            return View(customerMVC);
        }

        // GET: CustomerMVCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerMVCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender")] CustomerMVC customerMVC,OrderDa ord)
        {
            if (ModelState.IsValid)
            {
                db.OrderDas.Add(ord);
                db.CustomerMVCs.Add(customerMVC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerMVC);
        }

        // GET: CustomerMVCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerMVC customerMVC = db.CustomerMVCs.Find(id);
            if (customerMVC == null)
            {
                return HttpNotFound();
            }
            return View(customerMVC);
        }

        // POST: CustomerMVCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_ID,First_Name,Last_Name,E_mail,Phone,Age,Job_Title,Gender")] CustomerMVC customerMVC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerMVC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerMVC);
        }

        // GET: CustomerMVCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerMVC customerMVC = db.CustomerMVCs.Find(id);
            if (customerMVC == null)
            {
                return HttpNotFound();
            }
            return View(customerMVC);
        }

        // POST: CustomerMVCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerMVC customerMVC = db.CustomerMVCs.Find(id);
            db.CustomerMVCs.Remove(customerMVC);
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

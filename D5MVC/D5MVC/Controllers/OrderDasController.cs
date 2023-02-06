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
    public class OrderDasController : Controller
    {
        private Entities db = new Entities();

        // GET: OrderDas
        public ActionResult Index()
        {
            var orderDas = db.OrderDas.Include(o => o.CustomerMVC);
            return View(orderDas.ToList());
        }

        // GET: OrderDas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDa orderDa = db.OrderDas.Find(id);
            if (orderDa == null)
            {
                return HttpNotFound();
            }
            return View(orderDa);
        }

        // GET: OrderDas/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.CustomerMVCs, "Customer_ID", "First_Name");
            return View();
        }

        // POST: OrderDas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,OrderData")] OrderDa orderDa)
        {
            if (ModelState.IsValid)
            {
                db.OrderDas.Add(orderDa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.CustomerMVCs, "Customer_ID", "First_Name", orderDa.CustomerID);
            return View(orderDa);
        }

        // GET: OrderDas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDa orderDa = db.OrderDas.Find(id);
            if (orderDa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.CustomerMVCs, "Customer_ID", "First_Name", orderDa.CustomerID);
            return View(orderDa);
        }

        // POST: OrderDas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,OrderData")] OrderDa orderDa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.CustomerMVCs, "Customer_ID", "First_Name", orderDa.CustomerID);
            return View(orderDa);
        }

        // GET: OrderDas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDa orderDa = db.OrderDas.Find(id);
            if (orderDa == null)
            {
                return HttpNotFound();
            }
            return View(orderDa);
        }

        // POST: OrderDas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDa orderDa = db.OrderDas.Find(id);
            db.OrderDas.Remove(orderDa);
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

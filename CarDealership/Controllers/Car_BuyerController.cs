using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class Car_BuyerController : Controller
    {
        private CarDealershipContext db = new CarDealershipContext();

        // GET: Car_Buyer
        public ActionResult Index()
        {
            var car_Buyer = db.Car_Buyer.Include(c => c.Buyer).Include(c => c.Car);
            return View(car_Buyer.ToList());
        }

        // GET: Car_Buyer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Buyer car_Buyer = db.Car_Buyer.Find(id);
            if (car_Buyer == null)
            {
                return HttpNotFound();
            }
            return View(car_Buyer);
        }

        // GET: Car_Buyer/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName");
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber");
            return View();
        }

        // POST: Car_Buyer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Car_BuyerID,CarID,BuyerID")] Car_Buyer car_Buyer)
        {
            if (ModelState.IsValid)
            {
                db.Car_Buyer.Add(car_Buyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName", car_Buyer.BuyerID);
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber", car_Buyer.CarID);
            return View(car_Buyer);
        }

        // GET: Car_Buyer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Buyer car_Buyer = db.Car_Buyer.Find(id);
            if (car_Buyer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName", car_Buyer.BuyerID);
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber", car_Buyer.CarID);
            return View(car_Buyer);
        }

        // POST: Car_Buyer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Car_BuyerID,CarID,BuyerID")] Car_Buyer car_Buyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_Buyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "FirstName", car_Buyer.BuyerID);
            ViewBag.CarID = new SelectList(db.Cars, "CarID", "VinNumber", car_Buyer.CarID);
            return View(car_Buyer);
        }

        // GET: Car_Buyer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Buyer car_Buyer = db.Car_Buyer.Find(id);
            if (car_Buyer == null)
            {
                return HttpNotFound();
            }
            return View(car_Buyer);
        }

        // POST: Car_Buyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car_Buyer car_Buyer = db.Car_Buyer.Find(id);
            db.Car_Buyer.Remove(car_Buyer);
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

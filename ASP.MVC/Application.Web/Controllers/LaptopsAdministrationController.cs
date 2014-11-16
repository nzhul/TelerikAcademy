using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Application.Data;
using Application.Models;

namespace Application.Web.Controllers
{
    public class LaptopsAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LaptopsAdministration
        public ActionResult Index()
        {
            var laptops = db.Laptops.Include(l => l.Manufacturer);
            return View(laptops.ToList());
        }

        // GET: LaptopsAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: LaptopsAdministration/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ID", "Name");
            return View();
        }

        // POST: LaptopsAdministration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ManufacturerId,Model,MonitorSize,HardDiskSize,RamMemorySize,ImageUrl,Price,Weight,AdditionalParts,Description")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                db.Laptops.Add(laptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ID", "Name", laptop.ManufacturerId);
            return View(laptop);
        }

        // GET: LaptopsAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ID", "Name", laptop.ManufacturerId);
            return View(laptop);
        }

        // POST: LaptopsAdministration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ManufacturerId,Model,MonitorSize,HardDiskSize,RamMemorySize,ImageUrl,Price,Weight,AdditionalParts,Description")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ID", "Name", laptop.ManufacturerId);
            return View(laptop);
        }

        // GET: LaptopsAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: LaptopsAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laptop laptop = db.Laptops.Find(id);
            db.Laptops.Remove(laptop);
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

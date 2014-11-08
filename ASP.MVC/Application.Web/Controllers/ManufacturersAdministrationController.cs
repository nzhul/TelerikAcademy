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
    [Authorize(Roles="Admin")]
    public class ManufacturersAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManufacturersAdministration
        public ActionResult Index()
        {
            return View(db.Manufacturers.ToList());
        }

        // GET: ManufacturersAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: ManufacturersAdministration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturersAdministration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Manufacturer manufacturer)
        {
            if (db.Manufacturers.Any(x => x.Name == manufacturer.Name))
            {
                ModelState.AddModelError("Name", "There is already a manufacturer with that name.");
            } 
            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: ManufacturersAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: ManufacturersAdministration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Manufacturer manufacturer)
        {
            if (db.Manufacturers.Any(x => x.Name == manufacturer.Name))
            {
                ModelState.AddModelError("Name", "There is already a manufacturer with that name.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: ManufacturersAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: ManufacturersAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            foreach (var laptop in manufacturer.Laptops.ToList())
            {
                foreach (var vote in laptop.Votes.ToList())
                {
                    db.Votes.Remove(vote);
                }
                foreach (var comment in laptop.Comments.ToList())
                {
                    db.Comments.Remove(comment);
                }
                db.Laptops.Remove(laptop);
            }
            db.Manufacturers.Remove(manufacturer);
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

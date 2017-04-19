using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryTracker.DAL;
using InventoryTracker.Model;
using InventoryTracker.DAL.Repository;

namespace InventoryTracker.Controllers
{
    public class LocationTypesController : Controller
    {
        private LocationTypeRepository db = new LocationTypeRepository();

        // GET: LocationTypes
        public ActionResult Index()
        {
            return View(db.GetList());
        }

        // GET: LocationTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationType locationType = db.Find(id.Value);
            if (locationType == null)
            {
                return HttpNotFound();
            }
            return View(locationType);
        }

        // GET: LocationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] LocationType locationType)
        {
            if (ModelState.IsValid)
            {
                db.Add(locationType);
                return RedirectToAction("Index");
            }

            return View(locationType);
        }

        // GET: LocationTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationType locationType = db.Find(id.Value);
            if (locationType == null)
            {
                return HttpNotFound();
            }
            return View(locationType);
        }

        // POST: LocationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] LocationType locationType)
        {
            var model = db.Find(locationType.ID);
            bool isOk = TryUpdateModel(model);
            if (ModelState.IsValid && isOk)
            {
                db.Update(model);
                return RedirectToAction("Index");
            }
            return View(locationType);
        }

        // GET: LocationTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationType locationType = db.Find(id.Value);
            if (locationType == null)
            {
                return HttpNotFound();
            }
            return View(locationType);
        }

        // POST: LocationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationType locationType= db.Find(id);
            bool ok = db.Delete(id);
            if (ok)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", id);
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

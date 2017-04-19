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
    public class LocationsController : Controller
    {
        private LocationRepository LocationRepository = new LocationRepository();
        private LocationTypeRepository LocationTypeRepository = new LocationTypeRepository();

        // GET: Locations
        public ActionResult Index()
        {
            return View(LocationRepository.GetList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = LocationRepository.Find(id.Value);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            ViewBag.LocationTypeID = new SelectList(LocationTypeRepository.GetList(), "ID", "Type");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,LocationTypeID")] Location location)
        {
            if (ModelState.IsValid)
            {
                LocationRepository.Add(location);
                return RedirectToAction("Index");
            }

            ViewBag.LocationTypeID = new SelectList(LocationTypeRepository.GetList(), "ID", "Type", location.LocationTypeID);
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = LocationRepository.Find(id.Value);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationTypeID = new SelectList(LocationTypeRepository.GetList(), "ID", "Type", location.LocationTypeID);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,LocationTypeID")] Location location)
        {
            bool isOk = TryUpdateModel(location);
            if (ModelState.IsValid && isOk)
            {
                LocationRepository.Update(location);
                return RedirectToAction("Index");
            }
            ViewBag.LocationTypeID = new SelectList(LocationTypeRepository.GetList(), "ID", "Type", location.LocationTypeID);
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = LocationRepository.Find(id.Value);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool ok = LocationRepository.Delete(id);
            if (ok)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                LocationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

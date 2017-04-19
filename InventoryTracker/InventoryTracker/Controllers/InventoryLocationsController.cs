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
    public class InventoryLocationsController : Controller
    {
        private InventoryLocationRepository InventoryLocationRepository = new InventoryLocationRepository();
        private LocationRepository LocationRepository = new LocationRepository();
        private InventoryRepository InventoryRepository = new InventoryRepository();

        // GET: InventoryLocations
        public ActionResult Index()
        {
            return View(InventoryLocationRepository.GetList());
        }

        // GET: InventoryLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryLocation inventoryLocation = InventoryLocationRepository.Find(id.Value);
            if (inventoryLocation == null)
            {
                return HttpNotFound();
            }
            return View(inventoryLocation);
        }

        // GET: InventoryLocations/Create
        public ActionResult Create()
        {
            ViewBag.InventoryID = new SelectList(InventoryRepository.GetList(), "ID", "Name");
            ViewBag.LocationID = new SelectList(LocationRepository.GetList(), "ID", "Name");
            return View();
        }

        // POST: InventoryLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Quantity,InventoryID,LocationID")] InventoryLocation inventoryLocation)
        {
            if (ModelState.IsValid)
            {
                InventoryLocationRepository.Add(inventoryLocation);
                return RedirectToAction("Index");
            }

            ViewBag.InventoryID = new SelectList(InventoryRepository.GetList(), "ID", "Name", inventoryLocation.InventoryID);
            ViewBag.LocationID = new SelectList(LocationRepository.GetList(), "ID", "Name", inventoryLocation.LocationID);
            return View(inventoryLocation);
        }

        // GET: InventoryLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryLocation inventoryLocation = InventoryLocationRepository.Find(id.Value);
            if (inventoryLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryID = new SelectList(InventoryRepository.GetList(), "ID", "Name", inventoryLocation.InventoryID);
            ViewBag.LocationID = new SelectList(LocationRepository.GetList(), "ID", "Name", inventoryLocation.LocationID);
            return View(inventoryLocation);
        }

        // POST: InventoryLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Quantity,InventoryID,LocationID")] InventoryLocation inventoryLocation)
        {
            bool isOk = TryUpdateModel(inventoryLocation);
            if (ModelState.IsValid && isOk)
            {
                InventoryLocationRepository.Update(inventoryLocation);
                return RedirectToAction("Index");
            }
            ViewBag.InventoryID = new SelectList(InventoryRepository.GetList(), "ID", "Name", inventoryLocation.InventoryID);
            ViewBag.LocationID = new SelectList(LocationRepository.GetList(), "ID", "Name", inventoryLocation.LocationID);
            return View(inventoryLocation);
        }

        // GET: InventoryLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryLocation inventoryLocation = InventoryLocationRepository.Find(id.Value);
            if (inventoryLocation == null)
            {
                return HttpNotFound();
            }
            return View(inventoryLocation);
        }

        // POST: InventoryLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool ok = InventoryLocationRepository.Delete(id);
            if (ok)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                InventoryLocationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Models
{
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        public ActionResult Index(string sortOrder)
        {

            ViewBag.Now = DateTime.Now;
            
            ViewBag.VehicleTypeSortParm = sortOrder == "Type" ? "type_desc" : "Type";
            ViewBag.VehicleOwnerSortParm = sortOrder == "Owner" ? "owner_desc" : "Owner";
            ViewBag.VehicleLicensePlateSortParm = sortOrder == "LicensePlate" ? "licensePlate_desc" : "LicensePlate";
            ViewBag.VehicleParkingSortParm = sortOrder == "checkInTime_desc" ? "CheckInTime" : "checkInTime_desc";

            var vehicles = from v in db.Vehicles
                           select v;
         

            switch (sortOrder)
            {
                case "CheckInTime":
                    vehicles = vehicles.OrderBy(v => v.CheckInTime);
                    break;
                case "checkInTime_desc":
                    vehicles = vehicles.OrderByDescending(v => v.CheckInTime);
                    break;
                case "Type":
                    vehicles = vehicles.OrderBy(v => v.Type.Name);
                    break;
                case "type_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Type.Name);
                    break;
                case "Owner":
                    vehicles = vehicles.OrderBy(v => v.Owner.Name);
                    break;
                case "owner_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Owner.Name);
                    break;
                case "LicensePlate":
                    vehicles = vehicles.OrderBy(v => v.LicensePlate);
                    break;
                case "licensePlate_desc":
                    vehicles = vehicles.OrderByDescending(v => v.LicensePlate);
                    break;

                default:
                    vehicles = vehicles.OrderBy(v => v.CheckInTime);
                    break;
            }

            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.members = db.Members.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }).ToList();
            ViewBag.vehicletypes = db.VehicleTypes.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }).ToList();

            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LicensePlate,Color,Brand,Model,WheelAmount,CheckInTime")] Vehicle vehicle, String Owner, String Type)
        {
            if (ModelState.IsValid && int.TryParse(Owner, out int ownerId) && int.TryParse(Type, out int typeId))
            {
                vehicle.Owner = db.Members.First(m => m.Id == ownerId);
                vehicle.Type = db.VehicleTypes.First(t => t.Id == typeId);
                vehicle.CheckInTime = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,LicensePlate,Color,Brand,Model,WheelAmount,CheckInTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Receipt", vehicle);
        }

        public ActionResult Receipt(Vehicle vehicle)
        {

            //Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var now = DateTime.Now;
            var duration = DateTime.Now - vehicle.CheckInTime;
            ViewBag.Now = now;
            ViewBag.Duration = duration;
            ViewBag.Price = duration.TotalHours * 20;

            return View(vehicle);
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

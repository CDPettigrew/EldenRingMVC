using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EldenRing.Data;
using EldenRing.Models.LocationModels;
using EldenRing.Services;
using EldenRing.WebMVC.Models;

namespace EldenRing.WebMVC.Controllers
{
    public class LocationController : Controller
    {
        //GET: Location/Details
        public ActionResult Details(int id)
        {
            /*var ctx = new ApplicationDbContext();
            if(id == null)
            {
                return View();
            }
            Location location = ctx.Locations.Find(id);
            LocationDetail details = new LocationDetail();
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Region = location.Region,
                Weapons = location.Weapons,
                ArmorSets = location.ArmorSets
            };
            return View(details);*/
            var srv = CreateLocationService();
            var model = srv.GetLocationById(id);
            return View(model);
        }
        //GET: Location/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetLocationById(id);
            var model = new LocationEdit
            {
                LocationId = detail.LocationId,
                Name = detail.Name,
                Region = detail.Region
            };
            return View(model);
        }
        //POST: Location/Edit
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.LocationId != id)
            {
                ModelState.AddModelError("", "Id Mismatched");
                return View(model);
            }
            var service = CreateLocationService();
            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Your Location was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Location could not be updated.");
            return View(model);
        }
        //GET: Location/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var srv = CreateLocationService();
            var model = srv.GetLocationById(id);
            return View(model);
        }
        //POST: Location/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLocation(int id)
        {
            var service = CreateLocationService();
            service.DeleteLocation(id);
            TempData["SaveResult"] = "Your Location was removed.";
            return RedirectToAction("Index");
        }
        private LocationService CreateLocationService()
        {
            var service = new LocationService();
            return service;
        }
        // GET: Location
        public ActionResult Index()
        {
            var service = new LocationService();
            var model = service.GetLocations();
            return View(model);
        }
        //GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateLocationService();
            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Your Location was Created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Location could not be created.");
            return View(model);
        }
    }
}
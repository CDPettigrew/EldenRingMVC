using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EldenRing.Models.ArmorSetModels;
using EldenRing.Services;

namespace EldenRing.WebMVC.Controllers
{
    public class ArmorSetController : Controller
    {
        //GET: ArmorSet/Details
        public ActionResult Details(int id)
        {
            var srv = CreateArmorSetService();
            var model = srv.GetArmorSetId(id);
            return View(model);
        }
        //GET: ArmorSet/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateArmorSetService();
            var detail = service.GetArmorSetId(id);
            var model = new ArmorSetEdit
            {
                ArmorSetId = detail.ArmorSetId,
                Name = detail.Name,
                TypeOfArmor = detail.TypeOfArmor,
                Pieces = detail.Pieces,
                PhysicalProtection = detail.PhysicalProtection,
                MagicProtection = detail.MagicProtection,
                FireProtection = detail.FireProtection,
                LightProtection = detail.LightProtection,
                HolyProtection = detail.HolyProtection,
                LocationId = detail.LocationId
            };
            return View(model);
        }
        //POST: ArmorSet/Edit
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArmorSetEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.ArmorSetId != id)
            {
                ModelState.AddModelError("", "Id Mismatched");
                return View(model);
            }
            HttpPostedFileBase file = Request.Files["ImageData"];
            var service = CreateArmorSetService();
            if (service.UpdateArmorSet(file, model))
            {
                TempData["SaveResult"] = "Your ArmorSet was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your ArmorSet could not be updated.");
            return View(model);
        }
        //GET: ArmorSet/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var srv = CreateArmorSetService();
            var model = srv.GetArmorSetId(id);
            return View(model);
        }
        //POST: ArmorSet/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArmorSet(int id)
        {
            var service = CreateArmorSetService();
            service.DeleteArmorSet(id);
            TempData["SaveResult"] = "Your ArmorSet was removed";
            return RedirectToAction("Index");
        }
        private ArmorSetService CreateArmorSetService()
        {
            var service = new ArmorSetService();
            return service;
        }
        // GET: ArmorSet
        public ActionResult Index()
        {
            var service = new ArmorSetService();
            var model = service.GetArmorSets();
            return View(model);
        }
        //GET: ArmorSet/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: ArmorSet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArmorSetCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            HttpPostedFileBase file = Request.Files["ImageData"];
            var service = CreateArmorSetService();
            if (service.CreatArmorSet(file, model))
            {
                TempData["SaveResult"] = "Your ArmorSet was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "ArmorSet could not be created.");
            return View(model);
        }
        public ActionResult RetrieveImageAlt(int id)
        {
            var service = CreateArmorSetService();

            var armor = service.GetArmorSetId(id);
            if (armor.Image != null)
            {
                return File(armor.Image, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public ActionResult RetrieveImage(int id)
        {
            var service = CreateArmorSetService();
            byte[] cover = service.GetImageFromDataBaseA(id);

            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
    }
}
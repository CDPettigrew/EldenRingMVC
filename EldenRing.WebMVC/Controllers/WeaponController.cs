using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EldenRing.Models.WeaponModels;
using EldenRing.Services;

namespace EldenRing.WebMVC.Controllers
{
    public class WeaponController : Controller
    {
        //GET: Weapon/Details
        public ActionResult Details(int id)
        {
            var srv = CreateWeaponService();
            var model = srv.GetWeaponById(id);
            return View(model);
        }
        //GET: Weapon/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateWeaponService();
            var detail = service.GetWeaponById(id);
            var model = new WeaponEdit
            {
                WeaponId = detail.WeaponId,
                Name = detail.Name,
                TypeOfWeapon = detail.TypeOfWeapon,
                StrengthScaling = detail.StrengthScaling,
                DexterityScaling = detail.DexterityScaling,
                IntelligenceScaling = detail.IntelligenceScaling,
                FaithScaling = detail.FaithScaling,
                ArcaneScaling = detail.ArcaneScaling,
                PhysicalDamage = detail.PhysicalDamage,
                MagicDamage = detail.MagicDamage,
                FireDamage = detail.FireDamage,
                LightDamage = detail.LightDamage,
                HolyDamage = detail.HolyDamage,
                Bleed = detail.Bleed,
                Poison = detail.Poison,
                FrostBite = detail.FrostBite,
                ScarletRot = detail.ScarletRot,
                Sleep = detail.Sleep,
                Madness = detail.Madness,
                LocationId = detail.LocationId
            };
            return View(model);
        }
        //POST: Weapon/Edit
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditWeapon(int id, WeaponEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.WeaponId != id)
            {
                ModelState.AddModelError("", "Id Mismatched");
                return View(model);
            }
            var service = CreateWeaponService();
            if (service.UpdateWeapon(model))
            {
                TempData["SaveResult"] = "Your Weapon was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Weapon could not be updated.");
            return View(model);
        }
        //GET: Weapon/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var srv = CreateWeaponService();
            var model = srv.GetWeaponById(id);
            return View(model);
        }
        //POST: Weapon/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWeapon(int id)
        {
            var service = CreateWeaponService();
            service.DeleteWeapon(id);
            TempData["SaveResult"] = "Your Weapon was removed.";
            return RedirectToAction("Index");
        }
        private WeaponService CreateWeaponService()
        {
            var service = new WeaponService();
            return service;
        }
        // GET: Weapon
        public ActionResult Index()
        {
            var service = new WeaponService();
            var model = service.GetWeapons();
            return View(model);
        }
        //GET: Weapon/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Weapon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WeaponCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateWeaponService();
            if (service.CreateWeapon(model))
            {
                TempData["SaveResult"] = "Your weapon was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Weapon could not be created");
            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EldenRing.Models.SpellModels;
using EldenRing.Services;

namespace EldenRing.WebMVC.Controllers
{
    public class SpellController : Controller
    {
        //GET: Spell/Details
        public ActionResult Details(int id)
        {
            var srv = CreateSpellService();
            var model = srv.GetSpellId(id);
            return View(model);
        }
        //GET: Spell/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateSpellService();
            var detail = service.GetSpellId(id);
            var model = new SpellEdit
            {
                SpellId = detail.SpellId,
                Name = detail.Name,
                TypeOfSpell = detail.TypeOfSpell,
                Incantation = detail.Incantation,
                Scorcery = detail.Scorcery,
                FocusPoints = detail.FocusPoints,
                SlotUsage = detail.SlotUsage,
                IntelligenceScaling = detail.IntelligenceScaling,
                FaithScaling = detail.FaithScaling,
                ArcaneScaling = detail.ArcaneScaling,
                LocationId = detail.LocationId
            };
            return View(model);
        }
        //POST: Spell/Edit
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpellEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.SpellId != id)
            {
                ModelState.AddModelError("", "Id Mismatched");
                return View(model);
            }
            var service = CreateSpellService();
            if (service.UpdateSpell(model))
            {
                TempData["SaveResult"] = "Your Spell was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Spell could not be updated.");
            return View(model);
        }
        //GET: Spell/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var srv = CreateSpellService();
            var model = srv.GetSpellId(id);
            return View(model);
        }
        //POST: Spell/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSpell(int id)
        {
            var service = CreateSpellService();
            service.DeleteSpell(id);
            TempData["SaveResult"] = "Your Spell was removed";
            return RedirectToAction("Index");
        }
        private SpellService CreateSpellService()
        {
            var service = new SpellService();
            return service;
        }
        // GET: Spell
        public ActionResult Index()
        {
            var service = new SpellService();
            var model = service.GetSpells();
            return View(model);
        }
        //GET: Spell/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Spell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateSpellService();
            if (service.CreatSpells(model))
            {
                TempData["SaveResult"] = "Your Spell was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Spell could not be created.");
            return View(model);
        }
    }
}
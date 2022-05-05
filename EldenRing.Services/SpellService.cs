using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;
using EldenRing.Models.SpellModels;
using EldenRing.WebMVC.Models;

namespace EldenRing.Services
{
    public class SpellService
    {
        public bool CreatSpells(SpellCreate model)
        {
            var entity = new Spell()
            {
                Name = model.Name,
                TypeOfSpell = model.TypeOfSpell,
                Incantation = model.Incantation,
                Scorcery = model.Scorcery,
                FocusPoints = model.FocusPoints,
                SlotUsage = model.SlotUsage,
                IntelligenceScaling = model.IntelligenceScaling,
                FaithScaling = model.FaithScaling,
                ArcaneScaling = model.ArcaneScaling,
                LocationId = model.LocationId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Spells.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SpellListItem> GetSpells()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Spells.Select(w => new SpellListItem
                {
                    SpellId = w.SpellId,
                    Name = w.Name,
                    TypeOfSpell = w.TypeOfSpell,
                    Incantation = w.Incantation,
                    Scorcery = w.Scorcery,
                    LocationId = (int)w.LocationId,
                    Location = w.Location
                });
                return query.ToArray();
            }
        }
        public SpellDetail GetSpellId(int spellId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Spells.Single(w => w.SpellId == spellId);
                return
                    new SpellDetail
                    {
                        SpellId = entity.SpellId,
                        Name = entity.Name,
                        TypeOfSpell = entity.TypeOfSpell,
                        Incantation = entity.Incantation,
                        Scorcery = entity.Scorcery,
                        FocusPoints = entity.FocusPoints,
                        SlotUsage = entity.SlotUsage,
                        IntelligenceScaling = entity.IntelligenceScaling,
                        FaithScaling = entity.FaithScaling,
                        ArcaneScaling = entity.ArcaneScaling,
                        LocationId = (int)entity.LocationId,
                        Weapons = entity.Weapons,
                        Location = entity.Location
                    };
            }
        }
        public bool UpdateSpell(SpellEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Spells.Single(a => a.SpellId == model.SpellId);
                entity.Name = model.Name;
                entity.TypeOfSpell = model.TypeOfSpell;
                entity.Incantation = model.Incantation;
                entity.Scorcery = model.Scorcery;
                entity.FocusPoints = model.FocusPoints;
                entity.SlotUsage = model.SlotUsage;
                entity.IntelligenceScaling = model.IntelligenceScaling;
                entity.FaithScaling = model.FaithScaling;
                entity.ArcaneScaling = model.ArcaneScaling;
                entity.LocationId = model.LocationId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSpell(int spellId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Spells.Single(w => w.SpellId == spellId);
                ctx.Spells.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

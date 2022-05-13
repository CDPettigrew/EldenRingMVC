using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EldenRing.Data;
using EldenRing.Models.SpellModels;
using EldenRing.WebMVC.Models;

namespace EldenRing.Services
{
    public class SpellService
    {
        public byte[] GetImageFromDataBase(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var q = from temp in ctx.Spells where temp.SpellId == id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public bool CreatSpells(HttpPostedFileBase file, SpellCreate model)
        {
            model.Image = ConvertToBytes(file);
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
                LocationId = model.LocationId,
                Image = model.Image
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
                    Location = w.Location,
                    Image = w.Image
                    
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
                        Location = entity.Location,
                        Image = entity.Image
                    };
            }
        }
        public bool UpdateSpell(HttpPostedFileBase file, SpellEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                model.Image = ConvertToBytes(file);
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
                entity.Image = model.Image;
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

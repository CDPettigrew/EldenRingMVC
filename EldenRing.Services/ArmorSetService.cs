using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EldenRing.Data;
using EldenRing.Models.ArmorSetModels;
using EldenRing.WebMVC.Models;

namespace EldenRing.Services
{
    public class ArmorSetService
    {
        public byte[] GetImageFromDataBaseA(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var q = from temp in ctx.ArmorSets where temp.ArmorSetId == id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }
        public byte[] ConvertToBytesA(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public bool CreatArmorSet(HttpPostedFileBase file, ArmorSetCreate model)
        {
            model.Image = ConvertToBytesA(file);
            var entity = new ArmorSet()
            {
                Name = model.Name,
                TypeOfArmor = model.TypeOfArmor,
                Pieces = model.Pieces,
                PhysicalProtection = model.PhysicalProtection,
                MagicProtection = model.MagicProtection,
                FireProtection = model.FireProtection,
                LightProtection = model.LightProtection,
                HolyProtection = model.HolyProtection,
                LocationId = model.LocationId,
                Image = model.Image
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ArmorSets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ArmorSetListItem> GetArmorSets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ArmorSets.Select(w => new ArmorSetListItem
                {
                    ArmorSetId = w.ArmorSetId,
                    Name = w.Name,
                    TypeOfArmor = w.TypeOfArmor,
                    Pieces = w.Pieces,
                    PhysicalProtection = w.PhysicalProtection,
                    LocationId = (int)w.LocationId,
                    Location = w.Location,
                    Image = w.Image
                });
                return query.ToArray();
            }
        }
        public ArmorSetDetail GetArmorSetId(int armorSetId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ArmorSets.Single(w => w.ArmorSetId == armorSetId);
                return
                    new ArmorSetDetail
                    {
                        ArmorSetId = entity.ArmorSetId,
                        Name = entity.Name,
                        TypeOfArmor = entity.TypeOfArmor,
                        Pieces = entity.Pieces,
                        PhysicalProtection = entity.PhysicalProtection,
                        MagicProtection = entity.MagicProtection,
                        FireProtection = entity.FireProtection,
                        LightProtection = entity.LightProtection,
                        HolyProtection = entity.HolyProtection,
                        LocationId = (int)entity.LocationId,
                        Location = entity.Location,
                        Image = entity.Image
                    };
            }
        }
        public IEnumerable<ArmorSetListItem> GetArmorSetByType(ArmorType enumNum)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ArmorSets.Where(w => w.TypeOfArmor == enumNum).Select(a => new ArmorSetListItem
                {
                    ArmorSetId = a.ArmorSetId,
                    Name = a.Name,
                    TypeOfArmor = a.TypeOfArmor,
                    Pieces = a.Pieces,
                    PhysicalProtection = a.PhysicalProtection,
                    LocationId = (int)a.LocationId
                });
                return query.ToArray();
            }
        }
        public bool UpdateArmorSet(HttpPostedFileBase file, ArmorSetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                model.Image = ConvertToBytesA(file);
                var entity = ctx.ArmorSets.Single(a => a.ArmorSetId == model.ArmorSetId);
                entity.Name = model.Name;
                entity.TypeOfArmor = model.TypeOfArmor;
                entity.Pieces = model.Pieces;
                entity.PhysicalProtection = model.PhysicalProtection;
                entity.MagicProtection = model.MagicProtection;
                entity.FireProtection = model.FireProtection;
                entity.LightProtection = model.LightProtection;
                entity.HolyProtection = model.HolyProtection;
                entity.LocationId = model.LocationId;
                entity.Image = model.Image;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteArmorSet(int armorSetId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ArmorSets.Single(w => w.ArmorSetId == armorSetId);
                ctx.ArmorSets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

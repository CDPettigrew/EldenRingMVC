using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EldenRing.Data;
using EldenRing.Models.WeaponModels;
using EldenRing.WebMVC.Models;

namespace EldenRing.Services
{
    public class WeaponService
    {
        public byte[] GetImageFromDataBase(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var q = from temp in ctx.Weapons where temp.WeaponId == id select temp.Image;
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
        public bool CreateWeapon(HttpPostedFileBase file, WeaponCreate model)
        {
            model.Image = ConvertToBytes(file); 
            var entity = new Weapon()
            {
                Name = model.Name,
                TypeOfWeapon = model.TypeOfWeapon,
                StrengthScaling = model.StrengthScaling,
                DexterityScaling = model.DexterityScaling,
                IntelligenceScaling = model.IntelligenceScaling,
                FaithScaling = model.FaithScaling,
                ArcaneScaling = model.ArcaneScaling,
                PhysicalDamage = model.PhysicalDamage,
                MagicDamage = model.MagicDamage,
                FireDamage = model.FireDamage,
                LightDamage = model.LightDamage,
                HolyDamage = model.HolyDamage,
                Bleed = model.Bleed,
                Poison = model.Poison,
                FrostBite = model.FrostBite,
                ScarletRot = model.ScarletRot,
                Sleep = model.Sleep,
                Madness = model.Madness,
                LocationId = model.LocationId,
                SpellId = model.SpellId,
                Image = model.Image
            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Weapons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WeaponListItem> GetWeapons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Weapons.Select(e => new WeaponListItem
                {
                    WeaponId = e.WeaponId,
                    Name = e.Name,
                    TypeOfWeapon = e.TypeOfWeapon,
                    PhysicalDamage = e.PhysicalDamage,
                    LocationId = (int)e.LocationId,
                    Location = e.Location,
                    SpellId = (int)e.SpellId,
                    Image = e.Image
                });
                return query.ToArray();
            }
        }
        public WeaponDetail GetWeaponById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Weapons.Single(e => e.WeaponId == id);
                return
                    new WeaponDetail
                    {
                        WeaponId = entity.WeaponId,
                        Name = entity.Name,
                        TypeOfWeapon = entity.TypeOfWeapon,
                        StrengthScaling = entity.StrengthScaling,
                        DexterityScaling = entity.DexterityScaling,
                        IntelligenceScaling = entity.IntelligenceScaling,
                        FaithScaling = entity.FaithScaling,
                        ArcaneScaling = entity.ArcaneScaling,
                        PhysicalDamage = entity.PhysicalDamage,
                        MagicDamage = entity.MagicDamage,
                        FireDamage = entity.FireDamage,
                        LightDamage = entity.LightDamage,
                        HolyDamage = entity.HolyDamage,
                        Bleed = entity.Bleed,
                        Poison = entity.Poison,
                        FrostBite = entity.FrostBite,
                        ScarletRot = entity.ScarletRot,
                        Sleep = entity.Sleep,
                        Madness = entity.Madness,
                        LocationId = (int)entity.LocationId,
                        Location = entity.Location,
                        SpellId = (int)entity.SpellId,
                        Spell = entity.Spell,
                        Image = entity.Image
                    };
            }
        }
        public IEnumerable<WeaponListItem> GetWeaponByType(WeaponType enumNum)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Weapons.Where(e => e.TypeOfWeapon == enumNum).Select(e => new WeaponListItem
                {
                    WeaponId = e.WeaponId,
                    Name = e.Name,
                    TypeOfWeapon = e.TypeOfWeapon,
                    PhysicalDamage = e.PhysicalDamage,
                    LocationId = (int)e.LocationId,
                    SpellId = (int)e.SpellId
                });
                return query.ToArray();
            }
        }
        public bool UpdateWeapon(HttpPostedFileBase file, WeaponEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                model.Image = ConvertToBytes(file);
                var entity = ctx.Weapons.Single(e => e.WeaponId == model.WeaponId);
                entity.Name = model.Name;
                entity.TypeOfWeapon = model.TypeOfWeapon;
                entity.StrengthScaling = model.StrengthScaling;
                entity.DexterityScaling = model.DexterityScaling;
                entity.IntelligenceScaling = model.IntelligenceScaling;
                entity.FaithScaling = model.FaithScaling;
                entity.ArcaneScaling = model.ArcaneScaling;
                entity.PhysicalDamage = model.PhysicalDamage;
                entity.MagicDamage = model.MagicDamage;
                entity.FireDamage = model.FireDamage;
                entity.LightDamage = model.LightDamage;
                entity.HolyDamage = model.HolyDamage;
                entity.Bleed = model.Bleed;
                entity.Poison = model.Poison;
                entity.FrostBite = model.FrostBite;
                entity.ScarletRot = model.ScarletRot;
                entity.Sleep = model.Sleep;
                entity.Madness = model.Madness;
                entity.LocationId = model.LocationId;
                entity.SpellId = model.SpellId;
                entity.Image = model.Image;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteWeapon(int weaponId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Weapons.Single(w => w.WeaponId == weaponId);
                ctx.Weapons.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

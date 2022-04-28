using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.WeaponModels
{
    public class WeaponEdit
    {
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public WeaponType TypeOfWeapon { get; set; }
        public string StrengthScaling { get; set; }
        public string DexterityScaling { get; set; }
        public string IntelligenceScaling { get; set; }
        public string FaithScaling { get; set; }
        public string ArcaneScaling { get; set; }
        public string PhysicalDamage { get; set; }
        public string MagicDamage { get; set; }
        public string FireDamage { get; set; }
        public string LightDamage { get; set; }
        public string HolyDamage { get; set; }
        public bool Bleed { get; set; }
        public bool Poison { get; set; }
        public bool FrostBite { get; set; }
        public bool ScarletRot { get; set; }
        public bool Sleep { get; set; }
        public bool Madness { get; set; }
        public int LocationId { get; set; }
    }
}

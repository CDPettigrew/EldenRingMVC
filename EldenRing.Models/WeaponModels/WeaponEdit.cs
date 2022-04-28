using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.WeaponModels
{
    public class WeaponEdit
    {
        public int WeaponId { get; set; }
        [Display(Name = "Weapon Name")]
        public string Name { get; set; }
        [Display(Name = "Type of Weapon")]
        public WeaponType TypeOfWeapon { get; set; }
        [Display(Name = "STR Scaling")]
        public string StrengthScaling { get; set; }
        [Display(Name = "DEX Scaling")]
        public string DexterityScaling { get; set; }
        [Display(Name = "INT Scaling")]
        public string IntelligenceScaling { get; set; }
        [Display(Name = "FAI Scaling")]
        public string FaithScaling { get; set; }
        [Display(Name = "ARC Scaling")]
        public string ArcaneScaling { get; set; }
        [Display(Name = "Physical Damage")]
        public string PhysicalDamage { get; set; }
        [Display(Name = "Magic Damage")]
        public string MagicDamage { get; set; }
        [Display(Name = "Fire Damage")]
        public string FireDamage { get; set; }
        [Display(Name = "Light Damage")]
        public string LightDamage { get; set; }
        [Display(Name = "Holy Damage")]
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

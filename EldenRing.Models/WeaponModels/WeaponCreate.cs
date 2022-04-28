using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.WeaponModels
{
    public class WeaponCreate
    {
        [Required]
        [Display(Name ="Weapon Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Type of Weapon")]
        public WeaponType TypeOfWeapon { get; set; }
        [Required]
        [Display(Name ="STR Scaling")]
        public string StrengthScaling { get; set; }
        [Required]
        [Display(Name = "DEX Scaling")]
        public string DexterityScaling { get; set; }
        [Required]
        [Display(Name = "INT Scaling")]
        public string IntelligenceScaling { get; set; }
        [Required]
        [Display(Name = "FAI Scaling")]
        public string FaithScaling { get; set; }
        [Required]
        [Display(Name = "ARC Scaling")]
        public string ArcaneScaling { get; set; }
        [Required]
        [Display(Name ="Physical Damage")]
        public string PhysicalDamage { get; set; }
        [Required]
        [Display(Name = "Magic Damage")]
        public string MagicDamage { get; set; }
        [Required]
        [Display(Name = "Fire Damage")]
        public string FireDamage { get; set; }
        [Required]
        [Display(Name = "Light Damage")]
        public string LightDamage { get; set; }
        [Required]
        [Display(Name = "Holy Damage")]
        public string HolyDamage { get; set; }
        [Required]
        public bool Bleed { get; set; }
        [Required]
        public bool Poison { get; set; }
        [Required]
        public bool FrostBite { get; set; }
        [Required]
        public bool ScarletRot { get; set; }
        [Required]
        public bool Sleep { get; set; }
        [Required]
        public bool Madness { get; set; }
        [Required]
        public int LocationId { get; set; }
    }
}

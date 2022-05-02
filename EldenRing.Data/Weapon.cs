using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Data
{
    public enum WeaponType 
    { 
        Dagger = 1, 
        StraighSword, 
        GreatSword, 
        ColossalSword, 
        ThrustingSword, 
        HeavyThrustingSword, 
        CurvedSword, 
        CurvedGreatSword,
        Katana,
        TwinBlade,
        Axes,
        GreatAxe,
        Hammer,
        Flail,
        GreatHammer,
        ColossalWeapon,
        Spear,
        GreatSpear,
        Halberd,
        Reaper,
        Whip,
        Fist,
        Claw,
        LightBow,
        Bow,
        GreatBow,
        CrossBow,
        Ballistae,
        GlinStoneStaff,
        SacredSeal,
        Torches
    }
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        //[Required]
        //public Guid OwnerId { get; set; }
        [Required]
        [Display(Name="Weapon Name")]
        public string Name { get; set; }
        [Required]
        public WeaponType TypeOfWeapon { get; set; }
        [Required]
        public string StrengthScaling { get; set; }
        [Required]
        public string DexterityScaling { get; set; }
        [Required]
        public string IntelligenceScaling { get; set; }
        [Required]
        public string FaithScaling { get; set; }
        [Required]
        public string ArcaneScaling { get; set; }
        [Required]
        public string PhysicalDamage { get; set; }
        [Required]
        public string MagicDamage { get; set; }
        [Required]
        public string FireDamage { get; set; }
        [Required]
        public string LightDamage { get; set; }
        [Required]
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
        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }
    }
}

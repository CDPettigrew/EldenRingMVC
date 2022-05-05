using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.WeaponModels
{
    public class WeaponListItem
    {
        public int WeaponId { get; set; }
        [Display(Name = "Weapon Name")]
        public string Name { get; set; }
        [Display(Name = "Type of Weapon")]
        public WeaponType TypeOfWeapon { get; set; }
        [Display(Name = "Physical Damage")]
        public string PhysicalDamage { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int SpellId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.ArmorSetModels
{
    public class ArmorSetCreate
    {
        [Required]
        [Display(Name ="ArmorSet Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Type of Armor")]
        public ArmorType TypeOfArmor { get; set; }
        [Required]
        public string Pieces { get; set; }
        [Required]
        [Display(Name ="Physical Protection")]
        public double PhysicalProtection { get; set; }
        [Required]
        [Display(Name = "Magic Protection")]
        public double MagicProtection { get; set; }
        [Required]
        [Display(Name = "Fire Protection")]
        public double FireProtection { get; set; }
        [Required]
        [Display(Name = "Light Protection")]
        public double LightProtection { get; set; }
        [Required]
        [Display(Name = "Holy Protection")]
        public double HolyProtection { get; set; }
        [Required]
        public int LocationId { get; set; }
    }
}

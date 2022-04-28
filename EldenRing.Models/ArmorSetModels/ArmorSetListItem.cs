using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.ArmorSetModels
{
    public class ArmorSetListItem
    {
        public int ArmorSetId { get; set; }
        [Display(Name = "ArmorSet Name")]
        public string Name { get; set; }
        [Display(Name = "Type of Armor")]
        public ArmorType TypeOfArmor { get; set; }
        public string Pieces { get; set; }
        [Display(Name = "Physical Protection")]
        public double PhysicalProtection { get; set; }
        public int LocationId { get; set; }
    }
}

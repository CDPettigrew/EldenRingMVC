using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.LocationModels
{
    public class LocationDetail
    {
        public int LocationId { get; set; }
        [Display(Name ="Location")]
        public string Name { get; set; }
        [Display(Name ="Main Region")]
        public string Region { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<ArmorSet> ArmorSets { get; set; }
    }
}

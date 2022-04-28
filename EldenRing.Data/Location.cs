using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<ArmorSet> ArmorSets { get; set; } = new List<ArmorSet>();
    }
}

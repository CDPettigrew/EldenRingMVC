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
        //[Required]
        //public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Region { get; set; }
        public virtual List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public virtual List<ArmorSet> ArmorSets { get; set; } = new List<ArmorSet>();
        public virtual List<Spell> Spells { get; set; } = new List<Spell>();
    }
}

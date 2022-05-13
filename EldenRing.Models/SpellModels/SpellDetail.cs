using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.SpellModels
{
    public class SpellDetail
    {
        [Key]
        public int SpellId { get; set; }
        public string Name { get; set; }
        public SpellType TypeOfSpell { get; set; }
        public bool Incantation { get; set; }
        public bool Scorcery { get; set; }
        public int FocusPoints { get; set; }
        public int SlotUsage { get; set; }
        public double IntelligenceScaling { get; set; }
        public double FaithScaling { get; set; }
        public double ArcaneScaling { get; set; }
        public virtual List<Weapon> Weapons { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public byte[] Image { get; set; }
    }
}

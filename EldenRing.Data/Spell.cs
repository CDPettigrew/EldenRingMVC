using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Data
{
    public enum SpellType { Magic, Fire, Lightning, Holy, Bleed, Poison, Frostbite, ScarletRot, Buff, Debuff, Heal, Blight, Madness, Sleep}
    public class Spell
    {
        [Key]
        public int SpellId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public SpellType TypeOfSpell { get; set; }
        [Required]
        public bool Incantation { get; set; }
        [Required]
        public bool Scorcery { get; set; }
        [Required]
        public int FocusPoints { get; set; }
        [Required]
        public int SlotUsage { get; set; }
        [Required]
        public double IntelligenceScaling { get; set; }
        [Required]
        public double FaithScaling { get; set; }
        [Required]
        public double ArcaneScaling { get; set; }
        public virtual List<Weapon> Weapons { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }
    }
}

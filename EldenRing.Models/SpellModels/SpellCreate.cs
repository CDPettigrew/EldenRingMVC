using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.SpellModels
{
    public class SpellCreate
    {
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
        public int LocationId { get; set; }
        public byte[] Image { get; set; }
    }
}

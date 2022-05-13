using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenRing.Data;

namespace EldenRing.Models.SpellModels
{
    public class SpellListItem
    {
        public int SpellId { get; set; }
        public string Name { get; set; }
        public SpellType TypeOfSpell { get; set; }
        public bool Incantation { get; set; }
        public bool Scorcery { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public byte[] Image { get; set; }
    }
}

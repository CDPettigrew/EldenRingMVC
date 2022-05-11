using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Data
{
    public enum ArmorType { HeavyArmor, MediumArmor, LightArmor}
    public class ArmorSet
    {
        [Key]
        public int ArmorSetId { get; set; }
        //[Required]
        //public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ArmorType TypeOfArmor { get; set; }
        [Required]
        public string Pieces { get; set; }
        [Required]
        public double PhysicalProtection { get; set; }
        [Required]
        public double MagicProtection { get; set; }
        [Required]
        public double FireProtection { get; set; }
        [Required]
        public double LightProtection { get; set; }
        [Required]
        public double HolyProtection { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }
        public byte[] Image { get; set; }
    }
}

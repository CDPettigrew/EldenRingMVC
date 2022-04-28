using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Data
{
    public enum WeaponType { Dagger, StraighSword, GreatSword, ColossalSword, }
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
    }
}

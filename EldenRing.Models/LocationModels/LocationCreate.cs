using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Models.LocationModels
{
    public class LocationCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Region { get; set; }
    }
}

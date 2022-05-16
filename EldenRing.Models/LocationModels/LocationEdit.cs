using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRing.Models.LocationModels
{
    public class LocationEdit
    {
        public int LocationId { get; set; }
        [Display(Name = "Location")]
        public string Name { get; set; }
        [Display(Name = "Main Region")]
        public string Region { get; set; }
    }
}

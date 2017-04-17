using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Model
{
    public class LocationType : EntityBase
    {
        [Required]
        [Display(Name = "Tip lokacije")]
        public string Type { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}

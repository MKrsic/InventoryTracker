using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Model
{
    public class Location : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [ForeignKey("LocationType")]
        public int LocationTypeID { get; set; }

        public virtual LocationType LocationType { get; set; }
        public virtual ICollection<InventoryLocation> InventoryLocations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Model
{
    public class InventoryLocation : EntityBase
    {
        public virtual ICollection<Inventory> Item { get; set; }
        public virtual ICollection<Location> Location{ get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Količina može sadržavati samo znamenke od 0 do 9.")]
        [Display(Name = "Količina")]
        public int Quantity { get; set; }
    }
}

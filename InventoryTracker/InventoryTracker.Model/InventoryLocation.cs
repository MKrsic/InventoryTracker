using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Model
{
    public class InventoryLocation : EntityBase
    {
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Količina može sadržavati samo znamenke od 0 do 9.")]
        [Display(Name = "Količina")]
        public int Quantity { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryID { get; set; }

        //public virtual Inventory Inventory { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Model
{
    public class Inventory : EntityBase
    {
        [Required]
        [Display(Name = "Naziv inventara")]
        public string Name { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "Kod inventara može sadržavati do 6 znakova.")]
        [Display(Name = "Kod inventara")]
        public string Code { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Količina može sadržavati samo znamenke od 0 do 9.")]
        [Display(Name = "Ukupna količina")]
        public int TotalAmount { get; set; }
    }
}

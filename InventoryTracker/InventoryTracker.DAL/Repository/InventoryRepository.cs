using InventoryTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.DAL.Repository
{
    public class InventoryRepository : RepositoryBase<Inventory>
    {
        public List<Inventory> GetList()
        {
            return this.DbContext.Inventory
                .OrderBy(i => i.ID)
                .ToList();
        }

        public override Inventory Find(int id)
        {
            return this.DbContext.Inventory
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}

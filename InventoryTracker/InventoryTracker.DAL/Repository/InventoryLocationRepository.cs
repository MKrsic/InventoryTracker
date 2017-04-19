using InventoryTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace InventoryTracker.DAL.Repository
{
    public class InventoryLocationRepository : RepositoryBase<InventoryLocation>
    {
        public List<InventoryLocation> GetList()
        {
            return this.DbContext.InventoryLocation
                .Include(i => i.Location)
                .OrderBy(i => i.LocationID)
                .ToList();
        }

        public override InventoryLocation Find(int id)
        {
            return this.DbContext.InventoryLocation
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}

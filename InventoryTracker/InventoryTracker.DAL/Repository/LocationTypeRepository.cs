using InventoryTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.DAL.Repository
{
    public class LocationTypeRepository : RepositoryBase<LocationType>
    {
        public List<LocationType> GetList()
        {
            return this.DbContext.LocationTypes
                .OrderBy(i => i.ID)
                .ToList();
        }

        public override LocationType Find(int id)
        {
            return this.DbContext.LocationTypes
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}

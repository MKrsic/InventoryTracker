using InventoryTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace InventoryTracker.DAL.Repository
{
    public class LocationRepository : RepositoryBase<Location>
    {
        public List<Location> GetList()
        {
            return this.DbContext.Locations
                .Include(x => x.LocationType)
                .OrderBy(i => i.ID)
                .ToList();
        }

        public override Location Find(int id)
        {
            return this.DbContext.Locations
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}

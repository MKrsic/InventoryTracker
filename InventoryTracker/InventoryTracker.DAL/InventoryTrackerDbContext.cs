using InventoryTracker.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.DAL
{
    public class InventoryTrackerDbContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryLocation> InventoryLocation { get; set; }
        public DbSet<Location> Locations { get; set;}
        public DbSet<LocationType> LocationTypes { get; set; }
    }
}

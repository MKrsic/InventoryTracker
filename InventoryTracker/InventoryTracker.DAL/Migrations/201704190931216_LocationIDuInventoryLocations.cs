namespace InventoryTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationIDuInventoryLocations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryLocations", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.InventoryLocations", "LocationID");
            AddForeignKey("dbo.InventoryLocations", "LocationID", "dbo.Locations", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryLocations", "LocationID", "dbo.Locations");
            DropIndex("dbo.InventoryLocations", new[] { "LocationID" });
            DropColumn("dbo.InventoryLocations", "LocationID");
        }
    }
}

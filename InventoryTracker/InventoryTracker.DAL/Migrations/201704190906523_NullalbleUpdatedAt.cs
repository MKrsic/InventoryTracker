namespace InventoryTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullalbleUpdatedAt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.InventoryLocations", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Locations", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.LocationTypes", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocationTypes", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InventoryLocations", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Inventories", "UpdatedAt", c => c.DateTime(nullable: false));
        }
    }
}

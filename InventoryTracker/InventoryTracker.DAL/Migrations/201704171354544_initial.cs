namespace InventoryTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false, maxLength: 6),
                        TotalAmount = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InventoryLocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InventoryID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Inventories", t => t.InventoryID, cascadeDelete: true)
                .Index(t => t.InventoryID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        LocationTypeID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LocationTypes", t => t.LocationTypeID, cascadeDelete: true)
                .Index(t => t.LocationTypeID);
            
            CreateTable(
                "dbo.LocationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "LocationTypeID", "dbo.LocationTypes");
            DropForeignKey("dbo.InventoryLocations", "InventoryID", "dbo.Inventories");
            DropIndex("dbo.Locations", new[] { "LocationTypeID" });
            DropIndex("dbo.InventoryLocations", new[] { "InventoryID" });
            DropTable("dbo.LocationTypes");
            DropTable("dbo.Locations");
            DropTable("dbo.InventoryLocations");
            DropTable("dbo.Inventories");
        }
    }
}

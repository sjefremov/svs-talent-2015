namespace Registar.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RegNumber = c.String(nullable: false, maxLength: 200),
                        Producer = c.String(maxLength: 200),
                        Model = c.String(maxLength: 200),
                        Type = c.String(maxLength: 200),
                        ProductionDate = c.DateTime(storeType: "date"),
                        PurchaseDate = c.DateTime(storeType: "date"),
                        FrameMaterial = c.String(maxLength: 200),
                        Gears = c.Int(),
                        Colour = c.String(maxLength: 200),
                        City = c.String(maxLength: 200),
                        Status = c.String(maxLength: 200),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Password = c.String(maxLength: 100),
                        Adress = c.String(maxLength: 200),
                        PhoneNumber = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "UserId", "dbo.Users");
            DropIndex("dbo.Bikes", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Bikes");
        }
    }
}

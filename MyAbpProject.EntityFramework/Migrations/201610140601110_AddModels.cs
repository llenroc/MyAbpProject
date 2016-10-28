namespace MyAbpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barcodes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SerialNumber = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barcodes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Barcodes", new[] { "CustomerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Barcodes");
        }
    }
}

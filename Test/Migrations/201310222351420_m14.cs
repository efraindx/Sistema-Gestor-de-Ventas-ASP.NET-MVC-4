namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Images", new[] { "ProductID" });
            DropForeignKey("dbo.Images", "ProductID", "dbo.Products");
            DropTable("dbo.Images");
        }
    }
}

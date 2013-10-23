namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ImageClasses", new[] { "ProductID" });
            DropForeignKey("dbo.ImageClasses", "ProductID", "dbo.Products");
            DropTable("dbo.ImageClasses");
        }
    }
}

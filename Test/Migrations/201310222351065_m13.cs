namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProductID", "dbo.Products");
            DropIndex("dbo.Images", new[] { "ProductID" });
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Images", "ProductID");
            AddForeignKey("dbo.Images", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
    }
}

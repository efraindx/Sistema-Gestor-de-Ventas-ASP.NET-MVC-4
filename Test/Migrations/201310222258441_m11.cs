namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageClasses", "ProductID", "dbo.Products");
            DropIndex("dbo.ImageClasses", new[] { "ProductID" });
            DropTable("dbo.ImageClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ImageClasses", "ProductID");
            AddForeignKey("dbo.ImageClasses", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
    }
}

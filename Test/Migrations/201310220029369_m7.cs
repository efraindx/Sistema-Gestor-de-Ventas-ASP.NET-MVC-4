namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ConditionID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        ProductCondition_ProductConditionID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.ProductConditions", t => t.ProductCondition_ProductConditionID)
                .Index(t => t.CategoryID)
                .Index(t => t.ProductCondition_ProductConditionID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductConditions",
                c => new
                    {
                        ProductConditionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProductConditionID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "ProductCondition_ProductConditionID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Images", new[] { "ProductID" });
            DropForeignKey("dbo.Products", "ProductCondition_ProductConditionID", "dbo.ProductConditions");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Images", "ProductID", "dbo.Products");
            DropTable("dbo.ProductConditions");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Images");
        }
    }
}

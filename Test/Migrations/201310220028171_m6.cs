namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Product_Produt_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_Id1", "dbo.Categories");
            DropForeignKey("dbo.Products", "Condition_Id1", "dbo.Conditions");
            DropIndex("dbo.Images", new[] { "Product_Produt_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id1" });
            DropIndex("dbo.Products", new[] { "Condition_Id1" });
            DropTable("dbo.Images");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Conditions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Produt_Id = c.Int(nullable: false, identity: true),
                        Category_Id = c.Int(nullable: false),
                        Condition_Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Category_Id1 = c.Int(),
                        Condition_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Produt_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Product_Produt_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Products", "Condition_Id1");
            CreateIndex("dbo.Products", "Category_Id1");
            CreateIndex("dbo.Images", "Product_Produt_Id");
            AddForeignKey("dbo.Products", "Condition_Id1", "dbo.Conditions", "Id");
            AddForeignKey("dbo.Products", "Category_Id1", "dbo.Categories", "Id");
            AddForeignKey("dbo.Images", "Product_Produt_Id", "dbo.Products", "Produt_Id");
        }
    }
}

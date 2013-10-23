namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductCondition_ProductConditionID", "dbo.ProductConditions");
            DropIndex("dbo.Products", new[] { "ProductCondition_ProductConditionID" });
            RenameColumn(table: "dbo.Products", name: "ProductCondition_ProductConditionID", newName: "ProductConditionID");
            AddForeignKey("dbo.Products", "ProductConditionID", "dbo.ProductConditions", "ProductConditionID", cascadeDelete: true);
            CreateIndex("dbo.Products", "ProductConditionID");
            DropColumn("dbo.Products", "ConditionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ConditionID", c => c.Int(nullable: false));
            DropIndex("dbo.Products", new[] { "ProductConditionID" });
            DropForeignKey("dbo.Products", "ProductConditionID", "dbo.ProductConditions");
            RenameColumn(table: "dbo.Products", name: "ProductConditionID", newName: "ProductCondition_ProductConditionID");
            CreateIndex("dbo.Products", "ProductCondition_ProductConditionID");
            AddForeignKey("dbo.Products", "ProductCondition_ProductConditionID", "dbo.ProductConditions", "ProductConditionID");
        }
    }
}

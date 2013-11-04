namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Owner", c => c.String(nullable: false));
            AddColumn("dbo.Products", "DateOfPublication", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DateOfPublication");
            DropColumn("dbo.Products", "Owner");
        }
    }
}

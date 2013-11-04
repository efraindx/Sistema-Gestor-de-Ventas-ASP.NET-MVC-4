namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductReviews", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductReviews", "Date");
        }
    }
}

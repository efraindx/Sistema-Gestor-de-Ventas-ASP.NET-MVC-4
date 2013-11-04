namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductReviews", "User", c => c.String());
            AddColumn("dbo.ProductReviews", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductReviews", "Date");
            DropColumn("dbo.ProductReviews", "User");
        }
    }
}

namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "RatingPercent", c => c.Int(nullable: false));
            AddColumn("dbo.ProductReviews", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductReviews", "Rating");
            DropColumn("dbo.Products", "RatingPercent");
        }
    }
}

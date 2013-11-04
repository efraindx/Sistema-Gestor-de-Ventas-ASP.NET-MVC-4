namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Owner", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Owner", c => c.String(nullable: false));
        }
    }
}

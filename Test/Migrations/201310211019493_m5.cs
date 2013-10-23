namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.webpages_Membership");
        }
        
        public override void Down()
        {
           
        }
    }
}

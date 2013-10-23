namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Name", c => c.String(nullable: false));
            DropColumn("dbo.People", "FirstName");
            DropColumn("dbo.People", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "LastName", c => c.String());
            AddColumn("dbo.People", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.People", "Name");
        }
    }
}

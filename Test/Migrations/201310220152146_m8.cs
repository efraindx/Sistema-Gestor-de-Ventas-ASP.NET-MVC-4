namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Categories", "Nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Nombre", c => c.String());
            DropColumn("dbo.Categories", "Name");
        }
    }
}

namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.webpages_Membership",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        CreateDate = c.String(),
                        ConfirmationToken = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        LastPasswordFailureDate = c.String(),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(),
                        PasswordChangedDate = c.String(),
                        PasswordSalt = c.String(),
                        PasswordVerificationToken = c.String(),
                        PasswordVerificationTokenExpirationDate = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
        }
    }
}

namespace AcmeWebsite.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_DB_Change_Contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contact", "DateCreation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "DateCreation", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contact", "CreationDate");
        }
    }
}

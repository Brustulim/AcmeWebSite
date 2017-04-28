namespace AcmeWebsite.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_DB_Version_005 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "LastName", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "LastName", c => c.String(maxLength: 50, unicode: false));
        }
    }
}

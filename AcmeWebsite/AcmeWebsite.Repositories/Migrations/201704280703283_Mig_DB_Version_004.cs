using System.Data.Entity.Migrations;

namespace AcmeWebsite.Repositories.Migrations
{
    public partial class Mig_DB_Version_004 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "LastName", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "LastName", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
    }
}

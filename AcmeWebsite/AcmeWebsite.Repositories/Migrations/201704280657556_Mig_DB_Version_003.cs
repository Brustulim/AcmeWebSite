namespace AcmeWebsite.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_DB_Version_003 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contact", name: "City", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Contact", name: "City1", newName: "City");
            RenameColumn(table: "dbo.Contact", name: "__mig_tmp__0", newName: "State");
            AlterColumn("dbo.Contact", "City", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "City", c => c.String(nullable: false, maxLength: 2, unicode: false));
            RenameColumn(table: "dbo.Contact", name: "State", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Contact", name: "City", newName: "City1");
            RenameColumn(table: "dbo.Contact", name: "__mig_tmp__0", newName: "City");
        }
    }
}

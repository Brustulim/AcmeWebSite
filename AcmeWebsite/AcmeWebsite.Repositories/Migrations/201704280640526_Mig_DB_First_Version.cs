namespace AcmeWebsite.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_DB_First_Version : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 254, unicode: false),
                        Phone = c.String(maxLength: 10, unicode: false),
                        City = c.String(nullable: false, maxLength: 2, unicode: false),
                        City1 = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 255, unicode: false),
                        DateCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contact");
        }
    }
}

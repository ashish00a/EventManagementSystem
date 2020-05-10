namespace EMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reportadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        REPORTID = c.Int(nullable: false, identity: true),
                        USERID = c.Int(nullable: false),
                        EMAIL = c.String(nullable: false),
                        ISSUE = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.REPORTID);
            AddForeignKey("dbo.Reports", "USERID", "dbo.Users", "USERID", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}

namespace EMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        USERID = c.Int(nullable: false, identity: true),
                        USERNAME = c.String(),
                        GENDER = c.String(),
                        MOBILE = c.String(),
                        EMAIL = c.String(),
                        USERTYPE = c.String(),
                        USERLOGINNAME = c.String(),
                        USERPASSWORD = c.String(),
                    })
                .PrimaryKey(t => t.USERID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}

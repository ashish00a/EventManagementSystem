namespace EMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EVENTSTARTDATE", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "EVENTENDDATE", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "PAYMENTSTATUS", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EVENTNAME", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EVENTTYPE", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "USERNAME", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "GENDER", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "MOBILE", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Users", "EMAIL", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "USERTYPE", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "USERPASSWORD", c => c.String(nullable: false));
            DropColumn("dbo.Users", "USERLOGINNAME");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "USERLOGINNAME", c => c.String());
            AlterColumn("dbo.Users", "USERPASSWORD", c => c.String());
            AlterColumn("dbo.Users", "USERTYPE", c => c.String());
            AlterColumn("dbo.Users", "EMAIL", c => c.String());
            AlterColumn("dbo.Users", "MOBILE", c => c.String());
            AlterColumn("dbo.Users", "GENDER", c => c.String());
            AlterColumn("dbo.Users", "USERNAME", c => c.String());
            AlterColumn("dbo.Events", "EVENTTYPE", c => c.String());
            AlterColumn("dbo.Events", "EVENTNAME", c => c.String());
            AlterColumn("dbo.Bookings", "PAYMENTSTATUS", c => c.String());
            DropColumn("dbo.Events", "EVENTENDDATE");
            DropColumn("dbo.Events", "EVENTSTARTDATE");
        }
    }
}

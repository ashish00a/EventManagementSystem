namespace EMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedeventmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EVENTCOST", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "EVENTMANAGEMENTCOST", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "EVENTCONSULTANTCOST", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "EVENTPRICE");
            DropColumn("dbo.Events", "EVENTMANAGEMENTPRICE");
            DropColumn("dbo.Events", "EVENTCONSULTANTPRICE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EVENTCONSULTANTPRICE", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "EVENTMANAGEMENTPRICE", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "EVENTPRICE", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "EVENTCONSULTANTCOST");
            DropColumn("dbo.Events", "EVENTMANAGEMENTCOST");
            DropColumn("dbo.Events", "EVENTCOST");
        }
    }
}

namespace EMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventbookingtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BOOKINGID = c.Int(nullable: false, identity: true),
                        EVENTID = c.Int(nullable: false),
                        USERID = c.Int(nullable: false),
                        BOOKINGDATE = c.DateTime(nullable: false),
                        PAYMENTSTATUS = c.String(),
                    })
                .PrimaryKey(t => t.BOOKINGID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EVENTID = c.Int(nullable: false, identity: true),
                        EVENTNAME = c.String(),
                        EVENTTYPE = c.String(),
                        EVENTPRiCE = c.Int(nullable: false),
                        EVENTMANAGEMENTPRICE = c.Int(nullable: false),
                        EVENTCONSULTANTPRICE = c.Int(nullable: false),
                        EVENTWALLET = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EVENTID);
            AddForeignKey("dbo.Bookings", "EVENTID", "dbo.Events", "EVENTID", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "USERID", "dbo.Users", "USERID", cascadeDelete: true);

        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
            DropTable("dbo.Bookings");
        }
    }
}

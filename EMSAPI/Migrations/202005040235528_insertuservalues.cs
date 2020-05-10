namespace EMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertuservalues : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Users values('sivakumar','MALE','9703940684','marthasivakumar@gmail.com','ADMIN','siva4039','siva')");
            Sql("insert into Users values('rajul','MALE','9707896542','rajul@gmail.com','MANAGER','rajul1212','rajul')");
            Sql("insert into Users values('ashish','MALE','9635731595','ashish@gmail.com','CONSULTANT','ashish1212','ashish')");

            Sql("insert into Events values('uthsav','cultural',200000,50000,25000,0)");
           

        }

        public override void Down()
        {
        }
    }
}

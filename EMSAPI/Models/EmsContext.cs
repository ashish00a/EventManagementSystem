using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;

namespace EMSAPI.Models
{
    public class EmsContext: DbContext
    {
        public EmsContext() : base("EMS_MVC_CS")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}
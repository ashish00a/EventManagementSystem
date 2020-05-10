using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSAPI.Models
{
    public class AdminViewModel
    {
        public User Users { get; set; }
        public Event Events { get; set; }
        public Booking Bookings { get; set; }
    }
}
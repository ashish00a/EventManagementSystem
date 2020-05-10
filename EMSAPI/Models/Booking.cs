using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSAPI.Models
{
    public class Booking
    {
        [Display(Name = "Booking Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Booking Id required")]
        public int BOOKINGID { get; set; }

        [Display(Name = "Event Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Id required")]
        public int EVENTID { get; set; }

        [Display(Name = "User Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Id required")]
        public int USERID { get; set; }

        [Display(Name = "Date of Booking")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BOOKINGDATE { get; set; }

        [Display(Name = "Payment Status")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Payment Status required")]
        public string PAYMENTSTATUS { get; set; }
    }
}
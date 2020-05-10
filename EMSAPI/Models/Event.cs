using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSAPI.Models
{
    public class Event
    {
        [Display(Name = "Event Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Id required")]
        public int EVENTID { get; set; }

        [Display(Name = "Event Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Name required")]
        public string EVENTNAME { get; set; }

        [Display(Name = "Event Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Type required")]
        public string EVENTTYPE { get; set; }


        [Display(Name = "Event Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime  EVENTSTARTDATE { get; set; }

        [Display(Name = "Event end Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EVENTENDDATE { get; set; }

        [Display(Name = "Event Cost")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Cost required")]
        public int EVENTCOST { get; set; }

        [Display(Name = "Event Management Cost")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Management Cost required")]
        public int EVENTMANAGEMENTCOST { get; set; }

        [Display(Name = "Event Consultant Cost")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Consultant Cost required")]
        public int EVENTCONSULTANTCOST { get; set; }

        [Display(Name = "Event Wallet")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Wallet required")]
        public int EVENTWALLET { get; set; }
    }
}
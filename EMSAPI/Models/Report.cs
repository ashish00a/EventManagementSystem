using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSAPI.Models
{
    public class Report
    {
        [Display(Name = "Report Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Report Id required")]
        public int REPORTID { get; set; }

        [Display(Name = "User Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Id required")]
        public int USERID { get; set; }


        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        [Display(Name = "Issue")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Issue required")]
        public string ISSUE { get; set; }
    }
}
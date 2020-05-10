using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSAPI.Models
{
    public class User
    {
        [Display(Name = "User Id")]
        [Required(AllowEmptyStrings  = false, ErrorMessage = "User Id required")]
        public int USERID { get; set; }

        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Name required")]
        public string USERNAME { get; set; }

        [Display(Name = "Gender")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender required")]
        public string GENDER { get; set; }

        [Display(Name = "Mobile")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile required")]
        [MaxLength(10,ErrorMessage = "Maximum 10 digits allowed")]
        public string MOBILE { get; set; }

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        [Display(Name = "User Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Type required")]
        public string USERTYPE { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string USERPASSWORD { get; set; }
        
    }
}
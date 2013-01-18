using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace AutoBody.Models
{
    public class APICredentialsModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Source Name")]
        public string SourceName { get; set; }

        [Required]
        [Display(Name = "Source Password")]
        public string SourcePassword { get; set; }

        [Required]
        [Display(Name = "Site ID")]
        public int SiteID { get; set; }

        [Required]
        [Display(Name = "Staff Username")]
        public string StaffName { get; set; }

        [Required]
        [Display(Name = "Staff Password")]
        public string StaffPassword { get; set; }

        [Display(Name = "Staff ID")]
        public int StaffID { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitIndia.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string AadhaarNo { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        [DisplayName("Date Of Birth")]
        public System.DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }
        [DisplayName("Email ID")]
        public string EmailID { get; set; }
        public string ImageUrl { get; set; }
    }
    
}
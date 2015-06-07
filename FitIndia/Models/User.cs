using System;
using System.Collections.Generic;
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
        public System.DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string ImageUrl { get; set; }
    }
    
}
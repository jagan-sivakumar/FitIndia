using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitIndia.Models
{
    public class AadhaarLogin
    {
        [Required]
        [DisplayName("Aadhaar No")]
        public string AadhaarNo { get; set; }
        [Required]
        public string Pincode { get; set; }

    }
}
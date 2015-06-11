using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitIndia.Models
{
    public class AadhaarOtpAuth
    {
        public string AadhaarNo { get; set; }
        [Required]
        public string Otp { get; set; }
    }
}
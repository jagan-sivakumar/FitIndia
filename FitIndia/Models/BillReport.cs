using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitIndia.Models
{
    [Table("BillReport")]
    public class BillReport
    {
        [Key]
        public int BillID { get; set; }
        [DisplayName("Aadhaar No")]
        public string AadhaarNo { get; set; }
        [DisplayName("Report ID")]
        public int ReportID { get; set; }
        [Required]
        [DisplayName("Bill Date")]
        public System.DateTime BillDate { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [DisplayName("Treatment Cost")]
        public decimal TreatmentCost { get; set; }
        [DisplayName("Insurance Claim")]
        public string InsuranceClaim { get; set; }
    }
}
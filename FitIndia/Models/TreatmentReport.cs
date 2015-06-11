using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitIndia.Models
{
    [Table("TreatmentReport")]
    public class TreatmentReport
    {
        [Key]
        public int ReportID { get; set; }
        [DisplayName("Aadhaar No")]
        public string AadhaarNo { get; set; }
        [Required]
        [DisplayName("Date Of Treatment")]
        public System.DateTime DateOfTreatment { get; set; }
        [Required]
        [DisplayName("Treating Organization")]
        public string TreatingOrganization { get; set; }
        [Required]
        [DisplayName("Doctor Name")]
        public string DoctorName { get; set; }
        [DisplayName("Medical Condition")]
        public string MedicalCondition { get; set; }
        [Required]
        [DisplayName("Treatment Given")]
        public string TreatmentGiven { get; set; }
    }
}
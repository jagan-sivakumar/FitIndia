using System;
using System.Collections.Generic;
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
        public string AadhaarNo { get; set; }
        public System.DateTime DateOfTreatment { get; set; }
        public string TreatingOrganization { get; set; }
        public string DoctorName { get; set; }
        public string MedicalCondition { get; set; }
        public string TreatmentGiven { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FitIndia.Models
{
    [DataContract]
    public class AadhaarData
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public UserJson user { get; set; }
        [DataMember]
        public Otp otp { get; set; }
    }
    public class UserJson
    {
        public int id { get; set; }
        public string aadhar_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public string date_of_birth { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string photo { get; set; }
        public string gender { get; set; }
    }
    public class Otp
    {
        public bool success { get; set; }
        //public string __invalid_name__aadhaar-reference-code { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FitIndia.Models
{
    public class BusinessLayer
    {
        public void addUser(User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramAadhaarNo = new SqlParameter();
                paramAadhaarNo.ParameterName = "@AadhaarNo";
                paramAadhaarNo.Value = user.AadhaarNo;
                cmd.Parameters.Add(paramAadhaarNo);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = user.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramSex = new SqlParameter();
                paramSex.ParameterName = "@Sex";
                paramSex.Value = user.Sex;
                cmd.Parameters.Add(paramSex);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = user.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@Address";
                paramAddress.Value = user.Address;
                cmd.Parameters.Add(paramAddress);

                SqlParameter paramMobileNo = new SqlParameter();
                paramMobileNo.ParameterName = "@MobileNo";
                paramMobileNo.Value = user.MobileNo;
                cmd.Parameters.Add(paramMobileNo);

                SqlParameter paramEmailID = new SqlParameter();
                paramEmailID.ParameterName = "@EmailID";
                paramEmailID.Value = user.EmailID;
                cmd.Parameters.Add(paramEmailID);

                SqlParameter paramImageUrl = new SqlParameter();
                paramImageUrl.ParameterName = "@ImageUrl";
                paramImageUrl.Value = user.ImageUrl;
                cmd.Parameters.Add(paramImageUrl);             

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void addTreatment(TreatmentReport treatmentReport)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddTreatment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramAadhaarNo = new SqlParameter();
                paramAadhaarNo.ParameterName = "@AadhaarNo";
                paramAadhaarNo.Value = treatmentReport.AadhaarNo;
                cmd.Parameters.Add(paramAadhaarNo);

                SqlParameter paramDateOfTreatment = new SqlParameter();
                paramDateOfTreatment.ParameterName = "@DateOfTreatment";
                paramDateOfTreatment.Value = treatmentReport.DateOfTreatment;
                cmd.Parameters.Add(paramDateOfTreatment);

                SqlParameter paramTreatingOrganization = new SqlParameter();
                paramTreatingOrganization.ParameterName = "@TreatingOrganization";
                paramTreatingOrganization.Value = treatmentReport.TreatingOrganization;
                cmd.Parameters.Add(paramTreatingOrganization);

                SqlParameter paramDoctorName = new SqlParameter();
                paramDoctorName.ParameterName = "@DoctorName";
                paramDoctorName.Value = treatmentReport.DoctorName;
                cmd.Parameters.Add(paramDoctorName);

                SqlParameter paramMedicalCondition = new SqlParameter();
                paramMedicalCondition.ParameterName = "@MedicalCondition";
                paramMedicalCondition.Value = treatmentReport.MedicalCondition;
                cmd.Parameters.Add(paramMedicalCondition);

                SqlParameter paramTreatmentGiven = new SqlParameter();
                paramTreatmentGiven.ParameterName = "@TreatmentGiven";
                paramTreatmentGiven.Value = treatmentReport.TreatmentGiven;
                cmd.Parameters.Add(paramTreatmentGiven);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void addBill(BillReport billReport)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddBill", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramAadhaarNo = new SqlParameter();
                paramAadhaarNo.ParameterName = "@AadhaarNo";
                paramAadhaarNo.Value = billReport.AadhaarNo;
                cmd.Parameters.Add(paramAadhaarNo);

                SqlParameter paramReportID = new SqlParameter();
                paramReportID.ParameterName = "@ReportID";
                paramReportID.Value = billReport.ReportID;
                cmd.Parameters.Add(paramReportID);

                SqlParameter paramBillDate = new SqlParameter();
                paramBillDate.ParameterName = "@BillDate";
                paramBillDate.Value = billReport.BillDate;
                cmd.Parameters.Add(paramBillDate);

                SqlParameter paramCategory = new SqlParameter();
                paramCategory.ParameterName = "@Category";
                paramCategory.Value = billReport.Category;
                cmd.Parameters.Add(paramCategory);

                SqlParameter paramTreatmentCost = new SqlParameter();
                paramTreatmentCost.ParameterName = "@TreatmentCost";
                paramTreatmentCost.Value = billReport.TreatmentCost;
                cmd.Parameters.Add(paramTreatmentCost);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void updateBillClaim(int BillID,String ClaimStatus)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateClaim", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramBillID = new SqlParameter();
                paramBillID.ParameterName = "@BillID";
                paramBillID.Value = BillID;
                cmd.Parameters.Add(paramBillID);

                SqlParameter paramInsuranceClaim = new SqlParameter();
                paramInsuranceClaim.ParameterName = "@InsuranceClaim";
                paramInsuranceClaim.Value = ClaimStatus;
                cmd.Parameters.Add(paramInsuranceClaim);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public User jsonToObject(AadhaarData aadhaarData)
        {
            User user = new User();
            user.AadhaarNo = aadhaarData.user.aadhar_id;

            if (aadhaarData.user.name != null)
                user.Name = aadhaarData.user.name;
            else
                user.Name = "";

            if (aadhaarData.user.gender != null)
                user.Sex = aadhaarData.user.gender;
            else
                user.Sex = "";

            if (aadhaarData.user.date_of_birth != null)
            {
                user.DateOfBirth = Convert.ToDateTime(aadhaarData.user.date_of_birth);
            }
            else
            {
                user.DateOfBirth = DateTime.Now;
            }

            if (aadhaarData.user.address != null)
                user.Address = aadhaarData.user.address;
            else
                user.Address = "";

            if (aadhaarData.user.mobile != null)
                user.MobileNo = aadhaarData.user.mobile;
            else
                user.MobileNo = "";

            if (aadhaarData.user.email != null)
                user.EmailID = aadhaarData.user.email;
            else
                user.EmailID = "";

            user.ImageUrl = null;
            return user;
        }

    }
}
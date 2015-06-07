﻿using System;
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
    }
}
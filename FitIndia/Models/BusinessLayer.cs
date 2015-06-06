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
                paramAadhaarNo.Value = user;
                cmd.Parameters.Add(paramAadhaarNo);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = user;
                cmd.Parameters.Add(paramName);

                SqlParameter paramSex = new SqlParameter();
                paramSex.ParameterName = "@Sex";
                paramSex.Value = user;
                cmd.Parameters.Add(paramSex);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = user;
                cmd.Parameters.Add(paramDateOfBirth);

                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@Address";
                paramAddress.Value = user;
                cmd.Parameters.Add(paramAddress);

                SqlParameter paramMobileNo = new SqlParameter();
                paramMobileNo.ParameterName = "@MobileNo";
                paramMobileNo.Value = user;
                cmd.Parameters.Add(paramMobileNo);

                SqlParameter paramEmailID = new SqlParameter();
                paramEmailID.ParameterName = "@EmailID";
                paramEmailID.Value = user;
                cmd.Parameters.Add(paramEmailID);

                SqlParameter paramImageUrl = new SqlParameter();
                paramImageUrl.ParameterName = "@ImageUrl";
                paramImageUrl.Value = user;
                cmd.Parameters.Add(paramImageUrl);             

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
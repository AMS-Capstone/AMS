using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace AMS.App_Code
{
    public class DataAction
    {

        //TODO: create global connection string

        #region Settingsscreen
        //Create a GST code
        public static void CreateGSTEntry(int gstPercent, bool status)
            {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_createGSTEntry", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pGstPercent", gstPercent);
                cmd.Parameters.AddWithValue("pGSTStatus", status);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            }

        //Update a GST Code
        public static void UpdateGSTEntry(int gstId, int gstPercent, bool status)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_updateGSTEntry", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pGstID", gstId);
                cmd.Parameters.AddWithValue("pGstPercent", gstPercent);
                cmd.Parameters.AddWithValue("pGSTStatus", status);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //View GST entry
        public static DataTable GetGST()
        {
            DataTable dt = null;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_viewGSTEntries";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }
                }
            }
            return dt;
        }
        //Create condition status
        public static void CreateConditionStatus(string conditionCode, string conditionDescription)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_createConditionStatus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pConditionCode", conditionCode);
                cmd.Parameters.AddWithValue("pConditionDescription", conditionDescription);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateConditionStatus(int conditionID, string conditionDescription, string conditionCode)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_updateConditionStatus", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pConditionID", conditionID);
                cmd.Parameters.AddWithValue("pConditionDescription", conditionDescription);
                cmd.Parameters.AddWithValue("pConditionCode", conditionCode);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //View Condition Status
        public static DataTable GetConditionStatus()
        {
            DataTable dt = null;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_viewConditionStatus";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }

                }
            }
            return dt;
        }

        public static void CreateFeeType(double feeCost, string feeType)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_createFeeType", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pFeeCost", feeCost);
                cmd.Parameters.AddWithValue("pFeeType", feeType);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //Update Fee Type
        public static void UpdateFeeType(int feeID, double feeCost, string feeType)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_updateFeeType", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pFeeId", feeID);
                cmd.Parameters.AddWithValue("pFeeType", feeType);
                cmd.Parameters.AddWithValue("pFeeCost", feeCost);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //View Fee Type
        public static DataTable GetFeeType()
        {
            DataTable dt = null;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_viewFeeTypes";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }

                }
            }
            return dt;
        }


        //Create Payment Type
        public static void CreatePaymentType(string paymentDescription)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_createPaymentType", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pPaymentDescription", paymentDescription);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


//Update PaymentType
        public static void UpdatePaymentType(int paymentID, string paymentDescription)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_updatePaymentType", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pPaymentID", paymentID);
                cmd.Parameters.AddWithValue("pPaymentDescription", paymentDescription);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //View PaymentType
        public static DataTable GetPaymentType()
        {
            DataTable dt = null;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_viewPayumentType";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }

                }
            }
            return dt;
        }


        #endregion





    }

}
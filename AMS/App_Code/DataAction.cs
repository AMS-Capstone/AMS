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
        public void CreateGSTEntry(double gstPercent, bool status)
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
        public void UpdateGSTEntry(int gstId, double gstPercent, bool status)
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
        //Get GST by ID
        public DataTable GetGSTbyID(int gstID)
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_getGSTByID";
                    cmd.Parameters.AddWithValue("pGstID", gstID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }
                }
            }
            return dt;
        }
        //View GST entry
        public DataTable GetGST()
        {
            DataTable dt = new DataTable();
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
        public void CreateConditionStatus(string conditionCode, string conditionDescription)
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

        public  void UpdateConditionStatus(int conditionID, string conditionDescription, string conditionCode)
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
        public DataTable GetConditionStatus()
        {
            DataTable dt = new DataTable();
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
        public DataTable GetConditionStatusByID(int conditionID)
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_getConditionStatusByID";
                    cmd.Parameters.AddWithValue("pConditionID", conditionID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }
                }
            }
            return dt;
        }


        public DataTable GetPaymentTypeByID(int paymentID)
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_getPaymentTypeByID";
                    cmd.Parameters.AddWithValue("pPaymentTypeID", paymentID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }
                }
            }
            return dt;
        }


        public void CreateFeeType(double feeCost, string feeType)
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

        //Get FeeType by ID

        public DataTable GetFeeTypeByID(int feeID)
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_getFeeTypeByID";
                    cmd.Parameters.AddWithValue("pFeeID", feeID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }
                }
            }
            return dt;
        }

        //Update Fee Type
        public void UpdateFeeType(int feeID, double feeCost, string feeType)
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
        public DataTable GetFeeType()
        {
            DataTable dt = new DataTable();
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
        public void CreatePaymentType(string paymentDescription)
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
        public void UpdatePaymentType(int paymentID, string paymentDescription)
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
        public  DataTable GetPaymentType()
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "sp_viewPaymentType";
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
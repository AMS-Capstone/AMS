using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Configuration;
using AMS.App_Code.SuppportClasses;

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
                try{
                    MySqlCommand cmd = new MySqlCommand("sp_createGSTEntry", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pGstPercent", gstPercent);
                    cmd.Parameters.AddWithValue("pGSTStatus", status);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
        }

        //Update a GST Code
        public void UpdateGSTEntry(int gstId, double gstPercent, bool status)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("sp_updateGSTEntry", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pGstID", gstId);
                    cmd.Parameters.AddWithValue("pGstPercent", gstPercent);
                    cmd.Parameters.AddWithValue("pGSTStatus", status);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
        }
        //Get GST by ID
        public DataTable GetGSTbyID(int gstID)
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
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
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
            return dt;
        }
        //Create condition status
        public void CreateConditionStatus(string conditionCode, string conditionDescription)
        {
            try
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
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
        }

        public  void UpdateConditionStatus(int conditionID, string conditionDescription, string conditionCode)
        {
            try
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
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
        }

        //View Condition Status
        public DataTable GetConditionStatus()
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
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
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
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
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
            return dt;
        }


        public void CreateFeeType(double feeCost, string feeType)
        {
            try
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
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
        }

        //Get FeeType by ID

        public DataTable GetFeeTypeByID(int feeID)
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
            return dt;
        }

        //Update Fee Type
        public void UpdateFeeType(int feeID, double feeCost, string feeType)
        {
            try
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
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
        }

        //View Fee Type
        public DataTable GetFeeType()
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
            return dt;
        }


        //Create Payment Type
        public void CreatePaymentType(string paymentDescription)
        {
            try
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
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
        }


//Update PaymentType
        public void UpdatePaymentType(int paymentID, string paymentDescription)
        {
            try
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
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
        }

        //View PaymentType
        public  DataTable GetPaymentType()
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
            return dt;
        }


        #endregion

        #region VehicleScreen
        //GET SELLERS
        public DataTable GetSellers()
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "sp_viewSellers";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
            return dt;
        }

        //GET VEHICLE BY LOT NUMBER
        public DataTable GetVehicleByLotNumber(int lotNumber)
        {
            DataTable dt = new DataTable();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "sp_getVehicleByLotNumber";
                        cmd.Parameters.AddWithValue("pLotNumber", lotNumber);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                        }
                    }
                }
                catch (Exception ex)
                {
                    //Panic
                    throw ex;
                }
                finally
                {
                    //Tie the loose ends here
                }
            }
            return dt;
        }



        public int CreateVehicle(Vehicle vehicle)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
            int id = 0;
            
                
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("sp_createVehicle", conn);
            cmd.Parameters.AddWithValue("pLotNumber", vehicle.LotNumber);
            cmd.Parameters.AddWithValue("pYear", vehicle.Year);
            cmd.Parameters.AddWithValue("pMake", vehicle.Make);
            cmd.Parameters.AddWithValue("pModel", vehicle.Model);
            cmd.Parameters.AddWithValue("pVin", vehicle.Vin);
            cmd.Parameters.AddWithValue("pColor", vehicle.Color);
            cmd.Parameters.AddWithValue("pMileage", vehicle.Mileage);
            cmd.Parameters.AddWithValue("pProvince", vehicle.Province);
            cmd.Parameters.AddWithValue("pUnits", vehicle.Units);
            cmd.Parameters.AddWithValue("pTransmission", vehicle.Transmission);
            cmd.Parameters.AddWithValue("pSellerID", vehicle.SellerID);
            cmd.Parameters.AddWithValue("pOptions", vehicle.Options);

            MySqlParameter returnParameter = new MySqlParameter();
            returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnParameter);

            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(returnParameter.Value.ToString());
                conn.Close();
            }
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
                
            }
            return id;
        }

        public void CreateImage(byte[] data, int vehicleID )
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_createVehiclePicture", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pImage", MySqlDbType.Blob).Value = data;
                    cmd.Parameters.AddWithValue("pVehicleID", vehicleID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Panic
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
        }
        #endregion



    }

}
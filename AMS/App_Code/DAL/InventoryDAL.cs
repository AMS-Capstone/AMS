using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using AMS.App_Code.SuppportClasses;

namespace AMS.App_Code.DAL
{
    public class InventoryDAL
    {
        private string connectionString = "";

        public InventoryDAL()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count > 0)
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString.ToString();
            }
        }

        //Retrieves only vehicles that are for sale
        public DataSet viewInventoryVehicles()
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_viewInventoryVehicles";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "Vehicles");

            }
            catch (Exception ex)
            {
                //Panic
                throw;
            }
            finally
            {
                //Tie the loose ends here
            }
            return ds;
        }


        //Retrieves only vehicles that are for sale
        public DataSet getInventoryVehicles(int vehicleConditionRequirementID)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_getVehicleFees";
                cmd.Parameters.Add(new MySqlParameter("@pVehicleConReqID", vehicleConditionRequirementID));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                //Panic
                throw;
            }
            finally
            {
                //Tie the loose ends here
            }
            return ds;
        }


        //Create a new vehicle fee
        public int CreateVehicleFee(VehicleFee vehicleFee)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_createVehicleFee";
                cmd.Parameters.Add(new MySqlParameter("@pVehicleConReqID", vehicleFee.VehicleConditionRequirementID));
                cmd.Parameters.Add(new MySqlParameter("@pFeeID", vehicleFee.FeeID));
                cmd.Parameters.Add(new MySqlParameter("@pVehicleFeeCost", vehicleFee.VehicleFeeCost));

                MySqlParameter returnParameter = new MySqlParameter();
                returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(returnParameter);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(returnParameter.Value.ToString());
            }
            catch (Exception ex)
            {
                //Panic
                throw;
            }
            finally
            {
                //Tie the loose ends here
                conn.Close();
            }
            return id;
        }

        //Retrieves only vehicles that are for sale
        public DataSet GetVehicleConditionsRequirements(int vehicleConditionRequirementID)
        {
            DataSet ds = new DataSet();
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_getVehicleCondnReqs";
                cmd.Parameters.Add(new MySqlParameter("@pVehicleConReqID", vehicleConditionRequirementID));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                //Panic
                throw;
            }
            finally
            {
                //Tie the loose ends here
            }
            return ds;
        }

        public int CreateVehicleConditionsRequirements(VehicleConditionsRequirements vehicleCondnReqs)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_createVehicleCondnReqs";
                cmd.Parameters.Add(new MySqlParameter("@pVehicleID", vehicleCondnReqs.VehicleID));
                cmd.Parameters.Add(new MySqlParameter("@pReserve", vehicleCondnReqs.Reserve));
                cmd.Parameters.Add(new MySqlParameter("@pRecord", vehicleCondnReqs.Record));
                cmd.Parameters.Add(new MySqlParameter("@pCallOnHigh", vehicleCondnReqs.CallOnHigh));
                cmd.Parameters.Add(new MySqlParameter("@pComments", vehicleCondnReqs.Comments));
                cmd.Parameters.Add(new MySqlParameter("@pEstValue", vehicleCondnReqs.EstValue));
                cmd.Parameters.Add(new MySqlParameter("@pdateIn", vehicleCondnReqs.DateIn));
                cmd.Parameters.Add(new MySqlParameter("@pForSale", vehicleCondnReqs.ForSale));

                MySqlParameter returnParameter = new MySqlParameter();
                returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(returnParameter);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(returnParameter.Value.ToString());
            }
            catch (Exception ex)
            {
                //Panic
                throw;
            }
            finally
            {
                //Tie the loose ends here
                conn.Close();
            }
            return id;
        }
    }
}
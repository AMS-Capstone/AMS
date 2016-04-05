using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

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
        public DataSet viewIventoryVehicles()
        {
            DataSet ds = new DataSet("Auctions");
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
    }
}
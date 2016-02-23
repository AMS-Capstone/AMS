using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class BuyerDAL
    {
        private string connectionString = "";

        public BuyerDAL()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count > 0)
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString.ToString();
            }
        }

        //Get all Buyers
        public DataSet GetBuyers()
        {
            DataSet ds = new DataSet("Buyers");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "GET_BUYERS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "Buyers");
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
            return ds;
        }

        //Get all Buyers
        public int CreateBuyer(Buyer buyer)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "ADD_BUYER";
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerFirstName", buyer.BuyerFirstName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerLastName", buyer.BuyerLastName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerAddress", buyer.BuyerAddress));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerCity", buyer.BuyerCity));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerProvince", buyer.BuyerProvince));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPostalCode", buyer.BuyerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPhone", buyer.BuyerPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBidderNumber", buyer.BidderNum));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPermanent", buyer.BuyerIsPermanent));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBanned", buyer.BuyerIsBanned));

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
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
                conn.Close();
            }
            return id;
        }

        //Get all Buyers
        public int UpdateBuyer(Buyer buyer)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UPDATE_BUYER";
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerID", buyer.BuyerID));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerFirstName", buyer.BuyerFirstName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerLastName", buyer.BuyerLastName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerAddress", buyer.BuyerAddress));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerCity", buyer.BuyerCity));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerProvince", buyer.BuyerProvince));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPostalCode", buyer.BuyerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPhone", buyer.BuyerPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBidderNumber", buyer.BidderNum));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPermanent", buyer.BuyerIsPermanent));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBanned", buyer.BuyerIsBanned));

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
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
                conn.Close();
            }
            return id;
        }
    }
}
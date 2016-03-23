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
                cmd.CommandText = "sp_viewBuyers";
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

        //Create a new buyer
        public int CreateBuyer(Buyer buyer)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_createBuyer";
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerFirstName", buyer.BuyerFirstName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerLastName", buyer.BuyerLastName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerAddress", buyer.BuyerAddress));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerCity", buyer.BuyerCity));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerProvince", buyer.BuyerProvince));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPostalCode", buyer.BuyerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPhone", buyer.BuyerPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerLicense", buyer.BuyerDriverLicense));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBidderNumber", buyer.BidderNum));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPermanent", buyer.BuyerIsPermanent));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBanned", buyer.IsBanned));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerNotes", buyer.Notes));

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

        //Update a buyer
        public void UpdateBuyer(Buyer buyer)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_updateBuyer";
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerID", buyer.BuyerID));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerFirstName", buyer.BuyerFirstName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerLastName", buyer.BuyerLastName));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerAddress", buyer.BuyerAddress));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerCity", buyer.BuyerCity));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerProvince", buyer.BuyerProvince));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPostalCode", buyer.BuyerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPhone", buyer.BuyerPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerLicense", buyer.BuyerDriverLicense));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBidderNumber", buyer.BidderNum));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerPermanent", buyer.BuyerIsPermanent));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerBanned", buyer.IsBanned));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerNotes", buyer.Notes));

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
        }

        //Delete a buyer
        public void DeleteBuyer(int BuyerID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_deleteBuyer";
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerID", BuyerID));

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
        }
    }
}
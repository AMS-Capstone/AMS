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
                throw;
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
                cmd.Parameters.Add(new MySqlParameter("@pBuyerFirstName", buyer.BuyerFirstName));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerLastName", buyer.BuyerLastName));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerAddress", buyer.BuyerAddress));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerCity", buyer.BuyerCity));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerProvince", buyer.BuyerProvince));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerPostalCode", buyer.BuyerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerPhone", buyer.BuyerPhone));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerLicense", buyer.BuyerDriverLicense));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerBidderNumber", buyer.BidderNum));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerPermanent", buyer.BuyerIsPermanent));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerBanned", buyer.IsBanned));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerNotes", buyer.Notes));

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

        //Check if buyer is deletable
        public bool CheckIfBuyerIsDeletable(int buyerID)
        {
            bool allowed = false;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_checkIfBuyerIsDeletable";
                cmd.Parameters.Add(new MySqlParameter("@pBuyerID", buyerID));

                MySqlParameter returnParameter = new MySqlParameter();
                returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(returnParameter);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                allowed = Convert.ToBoolean(returnParameter.Value);
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
            return allowed;
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
                cmd.Parameters.Add(new MySqlParameter("@pBuyerID", buyer.BuyerID));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerFirstName", buyer.BuyerFirstName));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerLastName", buyer.BuyerLastName));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerAddress", buyer.BuyerAddress));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerCity", buyer.BuyerCity));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerProvince", buyer.BuyerProvince));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerPostalCode", buyer.BuyerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerPhone", buyer.BuyerPhone));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerLicense", buyer.BuyerDriverLicense));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerBidderNumber", buyer.BidderNum));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerPermanent", buyer.BuyerIsPermanent));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerBanned", buyer.IsBanned));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerNotes", buyer.Notes));

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
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
                cmd.Parameters.Add(new MySqlParameter("@pBuyerID", BuyerID));

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
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
        }
    }
}
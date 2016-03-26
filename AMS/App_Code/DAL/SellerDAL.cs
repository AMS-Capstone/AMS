using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class SellerDAL
    {
        private string connectionString = "";

        public SellerDAL()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count > 0)
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString.ToString();
            }
        }

        //Get all Sellers
        public DataSet GetSellers()
        {
            DataSet ds = new DataSet("Sellers");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_viewSellers";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "Sellers");
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

        //Create Seller
        public int CreateSeller(Seller seller)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_createSeller";
                cmd.Parameters.Add(new MySqlParameter("@pSellerCode", seller.SellerCode));
                cmd.Parameters.Add(new MySqlParameter("@pSellerName", seller.SellerName));
                cmd.Parameters.Add(new MySqlParameter("@pSellerAddress", seller.SellerAddress));
                cmd.Parameters.Add(new MySqlParameter("@pSellerCity", seller.SellerCity));
                cmd.Parameters.Add(new MySqlParameter("@pSellerProvince", seller.SellerProvince));
                cmd.Parameters.Add(new MySqlParameter("@pSellerPostalCode", seller.SellerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@pSellerPhone", seller.SellerPhone));
                cmd.Parameters.Add(new MySqlParameter("@pSellerOtherPhone", seller.SellerOtherPhone));
                cmd.Parameters.Add(new MySqlParameter("@pSellerFax", seller.SellerFax));
                cmd.Parameters.Add(new MySqlParameter("@pContactFirstName", seller.ContactFirstName));
                cmd.Parameters.Add(new MySqlParameter("@pContactLastName", seller.ContactLastName));
                //cmd.Parameters.Add(new MySqlParameter("@pSellerFileNumber", seller.ConFile));
                cmd.Parameters.Add(new MySqlParameter("@pSellerPrivate", seller.SellerIsPrivate));
                cmd.Parameters.Add(new MySqlParameter("@pGSTNumber", seller.SellerGSTNumber));

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

        //Check if seller is deletable
        public bool CheckIfSellerIsDeletable(int sellerID)
        {
            bool allowed = false;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_checkIfSellerIsDeletable";
                cmd.Parameters.Add(new MySqlParameter("@pSellerID", sellerID));

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

        //Update Seller
        public void UpdateSeller(Seller seller)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_updateSeller";
                cmd.Parameters.Add(new MySqlParameter("@pSellerID", seller.SellerID));
                cmd.Parameters.Add(new MySqlParameter("@pSellerCode", seller.SellerCode));
                cmd.Parameters.Add(new MySqlParameter("@pSellerName", seller.SellerName));
                cmd.Parameters.Add(new MySqlParameter("@pSellerAddress", seller.SellerAddress));
                cmd.Parameters.Add(new MySqlParameter("@pSellerCity", seller.SellerCity));
                cmd.Parameters.Add(new MySqlParameter("@pSellerProvince", seller.SellerProvince));
                cmd.Parameters.Add(new MySqlParameter("@pSellerPostalCode", seller.SellerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@pSellerPhone", seller.SellerPhone));
                cmd.Parameters.Add(new MySqlParameter("@pSellerOtherPhone", seller.SellerOtherPhone));
                cmd.Parameters.Add(new MySqlParameter("@pSellerFax", seller.SellerFax));
                cmd.Parameters.Add(new MySqlParameter("@pContactFirstName", seller.ContactFirstName));
                cmd.Parameters.Add(new MySqlParameter("@pContactLastName", seller.ContactLastName));
                //cmd.Parameters.Add(new MySqlParameter("@pSellerFileNumber", seller.ConFile));
                cmd.Parameters.Add(new MySqlParameter("@pSellerPrivate", seller.SellerIsPrivate));
                cmd.Parameters.Add(new MySqlParameter("@pGSTNumber", seller.SellerGSTNumber));

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

        //Delete Seller
        public void DeleteSeller(int SellerID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_deleteSeller";
                cmd.Parameters.Add(new MySqlParameter("@pSellerID", SellerID));

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
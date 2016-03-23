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
                throw ex;
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
                cmd.Parameters.Add(new MySqlParameter("@N_SellerCode", seller.SellerCode));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerName", seller.SellerName));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerAddress", seller.SellerAddress));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerCity", seller.SellerCity));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerProvince", seller.SellerProvince));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerPostalCode", seller.SellerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerPhone", seller.SellerPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerOtherPhone", seller.SellerOtherPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerFax", seller.SellerFax));
                cmd.Parameters.Add(new MySqlParameter("@N_ContactFirstName", seller.ContactFirstName));
                cmd.Parameters.Add(new MySqlParameter("@N_ContactLastName", seller.ContactLastName));
                //cmd.Parameters.Add(new MySqlParameter("@N_SellerFileNumber", seller.ConFile));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerPrivate", seller.SellerIsPrivate));
                cmd.Parameters.Add(new MySqlParameter("@N_GSTNumber", seller.SellerGSTNumber));

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

        //Update Seller
        public void UpdateSeller(Seller seller)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_updateSeller";
                cmd.Parameters.Add(new MySqlParameter("@N_SellerID", seller.SellerID));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerCode", seller.SellerCode));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerName", seller.SellerName));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerAddress", seller.SellerAddress));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerCity", seller.SellerCity));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerProvince", seller.SellerProvince));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerPostalCode", seller.SellerPostalCode));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerPhone", seller.SellerPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerOtherPhone", seller.SellerOtherPhone));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerFax", seller.SellerFax));
                cmd.Parameters.Add(new MySqlParameter("@N_ContactFirstName", seller.ContactFirstName));
                cmd.Parameters.Add(new MySqlParameter("@N_ContactLastName", seller.ContactLastName));
                //cmd.Parameters.Add(new MySqlParameter("@N_SellerFileNumber", seller.ConFile));
                cmd.Parameters.Add(new MySqlParameter("@N_SellerPrivate", seller.SellerIsPrivate));
                cmd.Parameters.Add(new MySqlParameter("@N_GSTNumber", seller.SellerGSTNumber));

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

        //Delete Seller
        public void DeleteSeller(int SellerID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_deleteSeller";
                cmd.Parameters.Add(new MySqlParameter("@N_SellerID", SellerID));

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
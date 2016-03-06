using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace AMS.App_Code.DAL
{
    public class AuctionMainDAL
    {
        private string connectionString = "";

        public AuctionMainDAL()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count > 0)
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString.ToString();
            }
        }

        /// <summary>
        /// Retrieves all data pertaining to one auction
        /// </summary>
        /// <param name="auctionID">the ID of the auction to retrieve data for</param>
        /// <returns>A DataSet containing AuctionData table</returns>
        public DataSet GetAuctionData(int auctionID)
        {
            DataSet ds = new DataSet("Buyers");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_getAuctionData";
                cmd.Parameters.Add(new MySqlParameter("@N_AuctionID", auctionID));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "AuctionData");
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

        /// <summary>
        /// Retrieves currently active GST
        /// </summary>
        /// <returns>GST</returns>
        public double GetActiveGST()
        {
            DataSet ds = new DataSet("GST");
            double gst = 5; // Setting default GST to 5%
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_getActiveGST";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "GST");
                gst = Convert.ToDouble(ds.Tables["GST"].Rows[0][0].ToString());
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
            return gst;
        }

        /// <summary>
        /// Retrieves payment types for the payment processing
        /// </summary>
        /// <returns>A dataset containing PaymentTypes table</returns>
        public DataSet GetPaymentTypes()
        {
            DataSet ds = new DataSet("sp_viewPaymentTypes");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "GET_PAYMENT_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "PaymentTypes");
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

        /// <summary>
        /// Creates a new auction sale record
        /// </summary>
        /// <param name="auctionSale">The auction sale object to create</param>
        /// <returns>Database ID of the newly created object</returns>
        public int CreateAuctionSale(AuctionSale auctionSale)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_createAuctionSale";
                cmd.Parameters.Add(new MySqlParameter("@N_AuctionID", auctionSale.AuctionID));
                cmd.Parameters.Add(new MySqlParameter("@N_VehicleID", auctionSale.VehicleID));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerID", auctionSale.BuyerID));
                cmd.Parameters.Add(new MySqlParameter("@N_BidderNumber", 0));
                cmd.Parameters.Add(new MySqlParameter("@N_SellingPrice", auctionSale.SellingPrice));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyersFee", auctionSale.BuyersFee));
                cmd.Parameters.Add(new MySqlParameter("@N_Deposit", auctionSale.Deposit));
                cmd.Parameters.Add(new MySqlParameter("@N_ConditonID", auctionSale.ConditionID));
                cmd.Parameters.Add(new MySqlParameter("@N_GSTID", auctionSale.GstID));
                cmd.Parameters.Add(new MySqlParameter("@N_Total", auctionSale.Total));
                cmd.Parameters.Add(new MySqlParameter("@N_Saledate", auctionSale.SaleDate));
                cmd.Parameters.Add(new MySqlParameter("@N_Notes", auctionSale.Notes));

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


        /// <summary>
        /// Updates auction sale in the database
        /// </summary>
        /// <param name="auctionSale">The new auction sale object with the old auction sale ID</param>
        public void UpdateAuctionSale(AuctionSale auctionSale)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_updateAuctionSale";
                cmd.Parameters.Add(new MySqlParameter("@N_AuctionSaleID", auctionSale.AuctionSaleID));
                cmd.Parameters.Add(new MySqlParameter("@N_AuctionID", auctionSale.AuctionID));
                cmd.Parameters.Add(new MySqlParameter("@N_VehicleID", auctionSale.VehicleID));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyerID", auctionSale.BuyerID));
                cmd.Parameters.Add(new MySqlParameter("@N_BidderNumber", 0));
                cmd.Parameters.Add(new MySqlParameter("@N_SellingPrice", auctionSale.SellingPrice));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyersFee", auctionSale.BuyersFee));
                cmd.Parameters.Add(new MySqlParameter("@N_Deposit", auctionSale.Deposit));
                cmd.Parameters.Add(new MySqlParameter("@N_ConditonID", auctionSale.ConditionID));
                cmd.Parameters.Add(new MySqlParameter("@N_GSTID", auctionSale.GstID));
                cmd.Parameters.Add(new MySqlParameter("@N_Total", auctionSale.Total));
                cmd.Parameters.Add(new MySqlParameter("@N_Saledate", auctionSale.SaleDate));
                cmd.Parameters.Add(new MySqlParameter("@N_Notes", auctionSale.Notes));

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

        /// <summary>
        /// Deletes an existing auction sale from the database
        /// </summary>
        /// <param name="auctionSaleID">the id of the sale to delete</param>
        public void DeleteAuctionSale(int auctionSaleID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_deleteAuctionSale";
                cmd.Parameters.Add(new MySqlParameter("@N_AuctionSaleID", auctionSaleID));
                
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

        /// <summary>
        /// Creates a payment in the database
        /// </summary>
        /// <param name="payment">Payment object to create</param>
        /// <returns>The database id of the payment created</returns>
        public int CreatePayment(Payment payment)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_createPayment";
                cmd.Parameters.Add(new MySqlParameter("@N_PaymentAmount", payment.PaymentAmount));
                cmd.Parameters.Add(new MySqlParameter("@N_AuctionSaleID", payment.AuctionSaleID));
                cmd.Parameters.Add(new MySqlParameter("@N_PaymentTypeID", payment.PaymentTypeID));
                cmd.Parameters.Add(new MySqlParameter("@N_Surcharges", payment.Surcharges));
                cmd.Parameters.Add(new MySqlParameter("@N_PaymentDate", payment.PaymentDate));

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
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace AMS.App_Code
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
            DataSet ds = new DataSet("AuctionData");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_getAuctionData";
                cmd.Parameters.Add(new MySqlParameter("@pAuctionID", auctionID));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "AuctionData");
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

        /// <summary>
        /// Retrieves currently active GST
        /// </summary>
        /// <returns>GST</returns>
        public GST GetActiveGST()
        {
            DataSet ds = new DataSet("GST");
            GST gst = new GST();
            // Setting default GST to 5%
            gst.GSTPercent = 5;
            gst.GSTID = 0;
            gst.GSTStatus = true;
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

                //Populate GST object
                gst.GSTID = Convert.ToInt32(ds.Tables["GST"].Rows[0]["GSTID"].ToString());
                gst.GSTPercent = Convert.ToInt32(ds.Tables["GST"].Rows[0]["GSTPercent"].ToString());
                gst.GSTStatus = Convert.ToBoolean(ds.Tables["GST"].Rows[0]["GSTStatus"].ToString());
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
                cmd.CommandText = "sp_viewPaymentTypes";
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

        /// <summary>
        /// This procedure retrieves all sale payments pertaining to an auction sale
        /// </summary>
        /// <returns>Sale Payments</returns>
        public DataSet GetSalePayments()
        {
            DataSet ds = new DataSet("SalePayments");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_viewAuctionSalePayments";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "SalePayments");
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
                cmd.Parameters.Add(new MySqlParameter("@pAuctionID", auctionSale.AuctionID));
                cmd.Parameters.Add(new MySqlParameter("@pVehicleID", auctionSale.VehicleID));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerID", auctionSale.BuyerID));
                cmd.Parameters.Add(new MySqlParameter("@pBidderNumber", 0));
                cmd.Parameters.Add(new MySqlParameter("@pSellingPrice", auctionSale.SellingPrice));
                cmd.Parameters.Add(new MySqlParameter("@pBuyersFee", auctionSale.BuyersFee));
                cmd.Parameters.Add(new MySqlParameter("@pDeposit", auctionSale.Deposit));
                cmd.Parameters.Add(new MySqlParameter("@pConditionID", auctionSale.ConditionID));
                cmd.Parameters.Add(new MySqlParameter("@pGSTID", auctionSale.GstID));
                cmd.Parameters.Add(new MySqlParameter("@pTotal", auctionSale.Total));
                cmd.Parameters.Add(new MySqlParameter("@pSaledate", auctionSale.SaleDate));
                cmd.Parameters.Add(new MySqlParameter("@pNotes", auctionSale.Notes));

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
                cmd.Parameters.Add(new MySqlParameter("@pAuctionSaleID", auctionSale.AuctionSaleID));
                cmd.Parameters.Add(new MySqlParameter("@pAuctionID", auctionSale.AuctionID));
                cmd.Parameters.Add(new MySqlParameter("@pVehicleID", auctionSale.VehicleID));
                cmd.Parameters.Add(new MySqlParameter("@pBuyerID", auctionSale.BuyerID));
                cmd.Parameters.Add(new MySqlParameter("@pBidderNumber", 0));
                cmd.Parameters.Add(new MySqlParameter("@pSellingPrice", auctionSale.SellingPrice));
                cmd.Parameters.Add(new MySqlParameter("@pBuyersFee", auctionSale.BuyersFee));
                cmd.Parameters.Add(new MySqlParameter("@pDeposit", auctionSale.Deposit));
                cmd.Parameters.Add(new MySqlParameter("@pConditionID", auctionSale.ConditionID));
                cmd.Parameters.Add(new MySqlParameter("@pGSTID", auctionSale.GstID));
                cmd.Parameters.Add(new MySqlParameter("@pTotal", auctionSale.Total));
                cmd.Parameters.Add(new MySqlParameter("@pSaledate", auctionSale.SaleDate));
                cmd.Parameters.Add(new MySqlParameter("@pNotes", auctionSale.Notes));

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
                cmd.Parameters.Add(new MySqlParameter("@pAuctionSaleID", auctionSaleID));
                
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
                cmd.Parameters.Add(new MySqlParameter("@pPaymentAmount", payment.PaymentAmount));
                cmd.Parameters.Add(new MySqlParameter("@pAuctionSaleID", payment.AuctionSaleID));
                cmd.Parameters.Add(new MySqlParameter("@pPaymentTypeID", payment.PaymentTypeID));
                cmd.Parameters.Add(new MySqlParameter("@pSurcharges", payment.Surcharges));
                cmd.Parameters.Add(new MySqlParameter("@pPaymentDate", payment.PaymentDate));

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
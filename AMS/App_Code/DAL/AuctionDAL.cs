using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace AMS.App_Code
{

    public class AuctionDAL
    {
        private string connectionString = "";

        public AuctionDAL()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count > 0)
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaryHanna"].ConnectionString.ToString();
            }
        }

         public DataSet findAuctions(String auctionYear)
         {
             DataSet ds = new DataSet("Auctions");
             MySqlConnection conn = new MySqlConnection(connectionString);
             MySqlDataAdapter da = new MySqlDataAdapter();

             try
             {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_findAuction";
                cmd.Parameters.Add(new MySqlParameter("@pAuctionYear", auctionYear));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "Auctions");
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


        public DataSet getAuctionYears()
        {
            DataSet ds = new DataSet("Auctions");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_getAuctionYears";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "Auctions");

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

        public DataSet viewVehiclesForSale()
        {
            DataSet ds = new DataSet("Auctions");
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_viewVehiclesForSale";
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


        //Create a new Auction
        public int createAuction(Auction auction)
        {
            int id = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "sp_createAuction";
                cmd.Parameters.Add(new MySqlParameter("@pAuctionDate", auction.AuctionDate));
                cmd.Parameters.Add(new MySqlParameter("@pAuctionTotal", auction.AuctionTotal));
                cmd.Parameters.Add(new MySqlParameter("@pSurcharges", auction.Surcharges));
                cmd.Parameters.Add(new MySqlParameter("@pCashCharges", auction.CashCharges));
                cmd.Parameters.Add(new MySqlParameter("@pChequeCharges", auction.ChequeCharges));
                cmd.Parameters.Add(new MySqlParameter("@pCreditCardCharges", auction.CreditCardCharges));

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

        //Create a new AuctionSale
        public int createAuctionSale(AuctionSale auctionSale)
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
                cmd.Parameters.Add(new MySqlParameter("@N_BidderNumber", auctionSale.BidderNumber));
                cmd.Parameters.Add(new MySqlParameter("@N_SellingPrice", auctionSale.SellingPrice));
                cmd.Parameters.Add(new MySqlParameter("@N_BuyersFee", auctionSale.BuyersFee));
                cmd.Parameters.Add(new MySqlParameter("@N_Deposit", auctionSale.Deposit));
                cmd.Parameters.Add(new MySqlParameter("@N_ConditionID", auctionSale.ConditionID));
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
                throw;
            }
            finally
            {
                //Tie the loose ends here
                conn.Close();
            }
            return id;
        }


/*
public DataSet findAuctions()
{
DataSet ds = new DataSet("Auctions");
MySqlConnection conn = new MySqlConnection(connectionString);
MySqlDataAdapter da = new MySqlDataAdapter();

try
{
MySqlCommand cmd = new MySqlCommand();
cmd.CommandText = "sp_findAuctions";
cmd.CommandType = CommandType.StoredProcedure;
cmd.Connection = conn;
da.SelectCommand = cmd;
da.Fill(ds, "Auctions");
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

*/



    }


}

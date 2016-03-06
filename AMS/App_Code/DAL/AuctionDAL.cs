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

         public DataSet findAuctions()
         {
             DataSet ds = new DataSet("Auctions");
             MySqlConnection conn = new MySqlConnection(connectionString);
             MySqlDataAdapter da = new MySqlDataAdapter();

             try
             {
                 MySqlCommand cmd = new MySqlCommand();
                 cmd.CommandText = "sp_findAuction";
                 //cmd.Parameters.Add(new MySqlParameter("@pAuctionYear", MySqlDbType.String, 4));
                 //   MySqlParameter returnParameter = new MySqlParameter();
                //cmd.Parameters.Add(returnParameter);
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
                throw ex;
            }
            finally
            {
                //Tie the loose ends here
            }
            return ds;
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

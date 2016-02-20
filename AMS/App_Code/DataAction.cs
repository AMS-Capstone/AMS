using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace AMS.App_Code
{
    public class DataAction
    {
        //This is the execute method just pass in the stored proc name    
        public static DataTable ExecuteQueryDataTable(string procName, MySqlParameter[] param)
        {
            DataTable data = null;
            string connectionString = ConfigurationManager.ConnectionStrings["GaryHannah"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                }
                return data;

            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.App_Code;
using System.Data;
namespace AMS
{
    public partial class Vehicles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load the sellers
            DataAction dataAction = new DataAction();
            DataTable dt = new DataTable();
            dt = dataAction.GetSellers();
            DDLSeller.DataSource = dt;
            DDLSeller.DataValueField = dt.Columns["SellerID"].ToString();
            DDLSeller.DataTextField = dt.Columns["SellerName"].ToString();
            DDLSeller.DataBind();
            DDLSeller.Items.Insert(0, new ListItem(String.Empty, String.Empty));

        }

        protected void BTNSearchByLotNumber_Click(object sender, EventArgs e)
        {
            //Find a vehicle by the LotNumber
        }
    }
}
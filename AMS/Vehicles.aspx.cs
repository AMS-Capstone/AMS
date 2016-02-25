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
            if(!IsPostBack)
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

            //Set the mileage units (NOT FROM DB)

            DDLUnits.Items.Insert(0, new ListItem("KM", "1"));
            DDLUnits.Items.Insert(1, new ListItem("Mi", "2"));
            DDLUnits.Items.Insert(2, new ListItem("Hours", "3"));
            }
        }

      
    }
}
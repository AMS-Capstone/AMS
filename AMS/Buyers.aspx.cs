using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AMS.App_Code;

namespace AMS
{
    public partial class Buyers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuyerDAL buyerService = new AMS.App_Code.BuyerDAL();
            DataSet buyers = buyerService.GetBuyers();
            if (buyers.Tables[0].Rows.Count > 0)
            {
                //TXTAddress.Text = buyers.Tables["Buyers"].Rows[0]["BuyerName"].ToString();
                DDLBuyerName.DataTextField = "BuyerName";
                DDLBuyerName.DataValueField = "BuyerID";
                DDLBuyerName.DataSource = buyers;
                DDLBuyerName.DataBind();
            }
            else
            {
                
            }
        }
    }
}
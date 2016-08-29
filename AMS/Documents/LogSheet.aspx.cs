using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.App_Code;

namespace AMS.Documents
{
    public partial class LogSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String vehicleList = Session["vehicleList"].ToString();
                Auction auction = (Auction)Session["AuctionDetails"];
                auctionDate.InnerText = auction.AuctionDate.ToString("MMMM dd, yyyy");
                carList.InnerHtml = vehicleList;
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
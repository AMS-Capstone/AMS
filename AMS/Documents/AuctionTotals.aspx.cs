using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.App_Code;

namespace AMS
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String report = Session["AuctionTotals"].ToString();
                Auction auction = (Auction)Session["AuctionDetails"];
                //body.InnerHtml = report;
                carDetails.InnerHtml = report;
                auctionDate.InnerHtml = auction.AuctionDate.ToString("MMMM dd, yyyy");
                totalSellingPrices.InnerHtml = auction.TotalSellingPrices.ToString("C2");
                totalFees.InnerHtml = auction.TotalFees.ToString("C2");
                totalGST.InnerHtml = auction.TotalGST.ToString("C2");
                grossTotal.InnerHtml = auction.GrossTotal.ToString("C2");
                depositsAndPayments.InnerHtml = auction.DepositsAndPayments.ToString("C2");
                receivables.InnerHtml = auction.Receivables.ToString("C2");
            }
            catch(Exception ex)
            {

            }
        }
    }
}
using AMS.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class AuctionMain : System.Web.UI.Page
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            foreach (GridViewRow row in GVAuction.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow &&
                    row.RowState.HasFlag(DataControlRowState.Edit) == false)
                {
                    // enable click on row to enter edit mode
                    row.Attributes["onclick"] =
                        ClientScript.GetPostBackClientHyperlink(GVAuction, "Edit$" + row.DataItemIndex, true);
                }
            }
            base.Render(writer);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String auctionIDString = "";
            try
            {
                auctionIDString = Request["AuctionID"];
            }
            catch (Exception ex) 
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
            int auctionID = 0;

            DataSet auctionData = new DataSet();
            AuctionMainDAL auctionService = new AuctionMainDAL();

            if (auctionIDString != null)
            {
                auctionID = Convert.ToInt16(auctionIDString);
            }

            if (auctionID != 0)
            {
                auctionData = auctionService.GetAuctionData(auctionID);
                try
                {
                    

                    
                    GVAuction.DataSource = auctionData.Tables[0].DefaultView;
                    GVAuction.DataBind();

                }
                catch (Exception ex)
                {
                    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                    "</label></div>";
                }
            }
            else
            {  
                //Alert about inability to connect to the server
                AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Could not retrieve any auction data from the server." +
                "</label></div>";
            }
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList DDLBidderNumbers;

                    //get current index selected
                    int current_eng_sk = Convert.ToInt32(GVAuction.DataKeys[e.Row.RowIndex].Value);
                    DDLBidderNumbers = e.Row.FindControl("DDLBidderNumbers") as DropDownList;
                    BuyerDAL buyerService = new AMS.App_Code.BuyerDAL();
                    DataSet buyers = new DataSet();
                    buyers = buyerService.GetBuyers();
                    DDLBidderNumbers.DataSource = buyers;
                    DDLBidderNumbers.DataTextField = "BidderNumber";
                    DDLBidderNumbers.DataValueField = "BuyerID";
                    DDLBidderNumbers.DataBind();
            }
        }

        protected void DDLBidderNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void BTNTotals_Click(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class BidderRegistration : System.Web.UI.Page
    {
        //A lot of code below is re-used from the Default page. Any changes made here will likely need to be made there as well.
        AuctionDAL auctionService = new AMS.App_Code.AuctionDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DataSet auctionYear = auctionService.getAuctionYears();
                    if (auctionYear.Tables[0].Rows.Count > 0)
                    {

                        DDLAuctionYear.DataTextField = "Year";
                        DDLAuctionYear.DataValueField = "Year";
                        DDLAuctionYear.DataSource = auctionYear;
                        DDLAuctionYear.DataBind();

                        DataSet auctions = auctionService.findAuctions(DDLAuctionYear.SelectedValue);
                        if (auctions.Tables[0].Rows.Count > 0)
                        {

                            LBAuctionList.DataTextField = "AuctionDate";
                            LBAuctionList.DataValueField = "AuctionId";
                            LBAuctionList.DataSource = auctions;
                            LBAuctionList.DataBind();
                            LBAuctionList.SelectedIndex = 0;
                            
                            DataSet auctionBidders = auctionService.viewAuctionBidders(Convert.ToInt32(LBAuctionList.SelectedValue.ToString()));
                            if (auctionBidders.Tables[0].Rows.Count > 0)
                            {
                                LBAuctionBidderList.DataTextField = "BidderNumber";
                                LBAuctionBidderList.DataValueField = "BidderNumber";
                                LBAuctionBidderList.DataSource = auctionBidders;
                                LBAuctionBidderList.DataBind();
                            }
                            //LBAuctionList.SelectedIndex = 0;
                        }
                        else
                        {
                            //display error for no auctions
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

        protected void DDLAuctionYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet auctions = auctionService.findAuctions(DDLAuctionYear.SelectedValue);
            if (auctions.Tables[0].Rows.Count > 0)
            {

                LBAuctionList.DataSource = auctions;
                LBAuctionList.DataTextField = "AuctionDate";
                LBAuctionList.DataValueField = "AuctionId";
                LBAuctionList.DataBind();
                //LBAuctionList.SelectedIndex = 0;
            }
        }

        protected void btnAddBidder_Click(object sender, EventArgs e)
        {
            if (LBAuctionList.SelectedValue == null || LBAuctionList.SelectedValue == "")
            {
                LBAuctionList.SelectedIndex = 0;
            }
            try
            {
                AuctionBidder auctionBidder = new AuctionBidder();
                auctionBidder.AuctionID = Convert.ToInt32(LBAuctionList.SelectedValue.ToString());
                auctionBidder.BidderNumber = Convert.ToInt32(TXTBidderNumber.Text.ToString());
                auctionService.createAuctionBidder(auctionBidder);

                DataSet auctionBidders = auctionService.viewAuctionBidders(Convert.ToInt32(LBAuctionList.SelectedValue.ToString()));
                if (auctionBidders.Tables[0].Rows.Count > 0)
                {
                    LBAuctionBidderList.DataTextField = "BidderNumber";
                    LBAuctionBidderList.DataValueField = "BidderNumber";
                    LBAuctionBidderList.DataSource = auctionBidders;
                    LBAuctionBidderList.DataBind();
                }

                AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Bidder was added with Number: " + auctionBidder.BidderNumber +
                    "</label></div>";
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

        protected void btnEditBidder_Click(object sender, EventArgs e)
        {
            if (LBAuctionBidderList.SelectedValue == null || LBAuctionBidderList.SelectedValue == "")
            {
                LBAuctionBidderList.SelectedIndex = 0;
            }
            try
            {
                AuctionBidder auctionBidder = new AuctionBidder();
                auctionBidder.AuctionID = Convert.ToInt32(LBAuctionList.SelectedValue.ToString());
                auctionBidder.BidderNumber = Convert.ToInt32(LBAuctionBidderList.SelectedValue.ToString());

                AuctionBidder newAuctionBidder = new AuctionBidder();
                newAuctionBidder.AuctionID = Convert.ToInt32(LBAuctionList.SelectedValue.ToString());
                newAuctionBidder.BidderNumber = Convert.ToInt32(TXTBidderNumber.Text.ToString());

                auctionService.editAuctionBidder(auctionBidder, newAuctionBidder);

                DataSet auctionBidders = auctionService.viewAuctionBidders(Convert.ToInt32(LBAuctionList.SelectedValue.ToString()));
                if (auctionBidders.Tables[0].Rows.Count > 0)
                {
                    LBAuctionBidderList.DataTextField = "BidderNumber";
                    LBAuctionBidderList.DataValueField = "BidderNumber";
                    LBAuctionBidderList.DataSource = auctionBidders;
                    LBAuctionBidderList.DataBind();
                }

                AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Bidder Number " + auctionBidder.BidderNumber  + " was changed to: " + newAuctionBidder.BidderNumber +
                    "</label></div>";
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

        protected void LBAuctionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBAuctionList.SelectedValue == null || LBAuctionList.SelectedValue == "")
            {
                LBAuctionList.SelectedIndex = 0;
            }
            try
            {
                DataSet auctionBidders = auctionService.viewAuctionBidders(Convert.ToInt32(LBAuctionList.SelectedValue.ToString()));
                if (auctionBidders.Tables[0].Rows.Count > 0)
                {
                    LBAuctionBidderList.DataTextField = "BidderNumber";
                    LBAuctionBidderList.DataValueField = "BidderNumber";
                    LBAuctionBidderList.DataSource = auctionBidders;
                    LBAuctionBidderList.DataBind();
                }
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

    }
}
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
    public partial class _Default : Page
    {
        AuctionDAL auctionService = new AMS.App_Code.AuctionDAL();

        protected void Page_load(object sender, EventArgs e)
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


                            //LBAuctionList.SelectedIndex = 0;
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

        protected void BTNSubmit_Click(object sender, EventArgs e)
        {
            if (LBAuctionList.SelectedValue == null || LBAuctionList.SelectedValue == "")
            {
                LBAuctionList.SelectedIndex = 0;
            }
            Response.Redirect("~/AuctionMain?AuctionID=" + LBAuctionList.SelectedValue);
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


    }
}
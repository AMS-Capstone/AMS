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

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet auctions = auctionService.findAuctions();
            if (auctions.Tables[0].Rows.Count > 0)
            {
                //TXTAddress.Text = buyers.Tables["Buyers"].Rows[0]["BuyerName"].ToString();
                //DDLBuyerName.DataTextField = "BuyerName";
                //DDLBuyerName.DataValueField = "BuyerID";
                //DDLBuyerName.DataSource = buyers;
                //DDLBuyerName.DataBind();

                LBAuctionList.DataSource = auctions;
                LBAuctionList.DataTextField = "AuctionDate";
                LBAuctionList.DataValueField = "AuctionId";
                LBAuctionList.DataBind();

            }
            else
            {

            }




        }

        protected void LBAuctionList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLAuctionYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
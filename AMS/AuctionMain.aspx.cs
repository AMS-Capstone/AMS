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

        DataSet auctionData = new DataSet();
        DataSet paymentTypes = new DataSet();
        DataSet ConditionStatuses = new DataSet();
        AuctionMainDAL auctionService = new AuctionMainDAL();
        DataAction dataAction = new DataAction();
        int auctionID = 0;

        BuyerDAL buyerService = new AMS.App_Code.BuyerDAL();
        DataSet buyers = new DataSet();

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

            if (auctionIDString != null)
            {
                auctionID = Convert.ToInt16(auctionIDString);
            }
            if (auctionID != 0)
            {
                try
                {
                    buyers = buyerService.GetBuyers();
                    paymentTypes = auctionService.GetPaymentTypes();
                    ConditionStatuses.Tables.Add(dataAction.GetConditionStatus());

                    auctionData = auctionService.GetAuctionData(auctionID);
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
                "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Could not retrieve any auction data from the server." +
                "</label></div>";
            }
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList DDLBidderNumbers = (DropDownList)e.Row.FindControl("DDLBidderNumbers");

                    DDLBidderNumbers.DataSource = buyers.Tables[0];
                    DDLBidderNumbers.DataTextField = "BidderNumber";
                    DDLBidderNumbers.DataValueField = "BuyerID";
                    DDLBidderNumbers.DataBind();
                    //DDLBidderNumbers.AutoPostBack = true;

                    //DataRowView dr = e.Row.DataItem as DataRowView;
                    String value1 = (e.Row.FindControl("lblBidderNumber") as Label).Text;
                    DDLBidderNumbers.Items.FindByValue(value1).Selected = true;


                    DropDownList DDLSaleStatuses = (DropDownList)e.Row.FindControl("DDLSaleStatuses");

                    DDLSaleStatuses.DataSource = ConditionStatuses.Tables[0];
                    DDLSaleStatuses.DataTextField = "Description";
                    DDLSaleStatuses.DataValueField = "ConditionID";
                    DDLSaleStatuses.DataBind();
                    //DDLSaleStatuses.AutoPostBack = true;

                    //DataRowView dr2 = e.Row.DataItem as DataRowView;
                    String value2 = (e.Row.FindControl("lblSaleStatus") as Label).Text;
                    DDLSaleStatuses.Items.FindByValue(value2).Selected = true;

                    //DropDownList DDLSaleStatuses = (DropDownList)e.Row.FindControl("DDLSaleStatuses");

                    //DDLSaleStatuses.DataSource = paymentTypes.Tables[0];
                    //DDLSaleStatuses.DataTextField = "PaymentDescription";
                    //DDLSaleStatuses.DataValueField = "PaymentTypeID";
                    //DDLSaleStatuses.DataBind();

                    ////DataRowView dr3 = e.Row.DataItem as DataRowView;
                    //String value3 = (e.Row.FindControl("lblSaleStatus") as Label).Text;
                    //DDLSaleStatuses.Items.FindByValue(value3).Selected = true;
                }
            }
        }

        private void updateAuctionSale(AuctionSale auctionSale)
        {
            auctionService.UpdateAuctionSale(auctionSale);
        }

        private void createPayment(Payment payment)
        {
            auctionService.CreatePayment(payment);
        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVAuction.EditIndex = e.NewEditIndex;
            try
            {
                auctionData = auctionService.GetAuctionData(auctionID);
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

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                   "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                   "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Test" +
                   "</label></div>";
        }

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVAuction.EditIndex = -1;
            DataBind();
        }

        protected void DDLBidderNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void DDLSaleStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void BTNTotals_Click(object sender, EventArgs e)
        {

        }

         //AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
         //       "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
         //       "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Test" +
         //       "</label></div>";
    }
}
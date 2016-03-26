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
        int counter = 0;

        BuyerDAL buyerService = new AMS.App_Code.BuyerDAL();
        DataSet buyers = new DataSet();

        //protected override void Render(System.Web.UI.HtmlTextWriter writer)
        //{
        //    foreach (GridViewRow row in GVAuction.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow &&
        //            row.RowState.HasFlag(DataControlRowState.Edit) == false)
        //        {
        //            // enable click on row to enter edit mode
        //            row.Attributes["onclick"] =
        //                ClientScript.GetPostBackClientHyperlink(GVAuction, "Edit$" + row.DataItemIndex, true);

        //        }
        //    }
        //    base.Render(writer);
        //}

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
                    AlertDiv.InnerHtml = "";
                    buyers = buyerService.GetBuyers();
                    ConditionStatuses.Tables.Add(dataAction.GetConditionStatus());
                    
                    paymentTypes = auctionService.GetPaymentTypes();

                    if (paymentTypes.Tables.Count > 0)
                    {
                        if (DDLPaymentTypes != null)
                        {
                            //Providing payment types for the modal popup
                            DDLPaymentTypes.DataSource = paymentTypes.Tables[0];
                            DDLPaymentTypes.DataTextField = "PaymentDescription";
                            DDLPaymentTypes.DataValueField = "PaymentTypeID";
                            DDLPaymentTypes.DataBind();
                        }

                        //Here we will provide surcharges for the modal popup
                        ULContainer.InnerHtml = "<ul style=\"display: none\">";
                        foreach (DataRow row in paymentTypes.Tables[0].Rows)
                        {
                            ULContainer.InnerHtml += "<li class=\"hiddenList\">" + row["SurchargeInPercent"].ToString() + "</li>";
                        } 

                        //Closing the UL container
                        ULContainer.InnerHtml += "</ul>";
                    }

                    if (!IsPostBack)
                    {

                        auctionData = auctionService.GetAuctionData(auctionID);

                        if (auctionData.Tables.Count > 0 && auctionData.Tables[0].Rows.Count > 0)
                        {
                            GVAuction.DataSource = auctionData.Tables[0].DefaultView;
                            GVAuction.DataBind();
                        }
                        else
                        {
                            //Alert about no cars belonging to an auction
                            AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                            "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                            "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "No cars assigned to the auction at the moment!" +
                            "</label></div>";
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
                    String value1 = (e.Row.FindControl("lblBuyerID") as Label).Text;
                    DDLBidderNumbers.Items.FindByValue(value1).Selected = true;
                    (e.Row.FindControl("lblBidderNumber2") as Label).Text = DDLBidderNumbers.SelectedItem.Text;


                    DropDownList DDLSaleStatuses = (DropDownList)e.Row.FindControl("DDLSaleStatuses");

                    DDLSaleStatuses.DataSource = ConditionStatuses.Tables[0];
                    DDLSaleStatuses.DataTextField = "Description";
                    DDLSaleStatuses.DataValueField = "ConditionID";
                    DDLSaleStatuses.DataBind();
                    //DDLSaleStatuses.AutoPostBack = true;

                    //DataRowView dr2 = e.Row.DataItem as DataRowView;
                    String value2 = (e.Row.FindControl("lblConditionID") as Label).Text;
                    DDLSaleStatuses.Items.FindByValue(value2).Selected = true;
                    (e.Row.FindControl("lblSaleStatus2") as Label).Text = DDLSaleStatuses.SelectedItem.Text;

                    //DropDownList DDLSaleStatuses = (DropDownList)e.Row.FindControl("DDLSaleStatuses");

                    //DDLPaymentTypes.DataSource = paymentTypes.Tables[0];
                    //DDLPaymentTypes.DataTextField = "PaymentDescription";
                    //DDLPaymentTypes.DataValueField = "PaymentTypeID";
                    //DDLPaymentTypes.DataBind();

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
            //AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
            //       "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
            //       "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Counter: " + counter.ToString() +
            //       "</label></div>";
            //counter += 1;

            //Save auction sale ID to the session
            

            GVAuction.EditIndex = e.NewEditIndex;
            try
            {
                auctionData = auctionService.GetAuctionData(auctionID);
                GVAuction.DataSource = auctionData.Tables[0].DefaultView;
                GVAuction.DataBind();

                DataRow row = auctionData.Tables[0].Rows[e.NewEditIndex];
                Session["AuctionSaleID"] = row["AuctionSaleID"].ToString();
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
            //Assemble AuctionSale from the updated data in DataRow
            AuctionSale sale = new AuctionSale();
            DropDownList DDLBidderNumbers = (DropDownList)GVAuction.Rows[e.RowIndex].FindControl("DDLBidderNumbers");
            sale.BuyerID = Convert.ToInt32(DDLBidderNumbers.SelectedValue.ToString());

            DropDownList DDLSaleStatuses = (DropDownList)GVAuction.Rows[e.RowIndex].FindControl("DDLSaleStatuses");
            sale.ConditionID = Convert.ToInt32(DDLSaleStatuses.SelectedValue.ToString());

            TextBox txtSellingPrice = (TextBox)GVAuction.Rows[e.RowIndex].FindControl("txtSellingPrice");
            sale.SellingPrice = Convert.ToInt32(txtSellingPrice.Text.ToString());

            TextBox txtBuyersFee = (TextBox)GVAuction.Rows[e.RowIndex].FindControl("txtBuyersFee");
            sale.BuyersFee = Convert.ToInt32(txtBuyersFee.Text.ToString());

            Label lblVehicleID = (Label)GVAuction.Rows[e.RowIndex].FindControl("lblVehicleID");
            sale.VehicleID = Convert.ToInt32(lblVehicleID.Text.ToString());

            Label lblAuctionSaleID = (Label)GVAuction.Rows[e.RowIndex].FindControl("lblAuctionSaleID");
            sale.AuctionSaleID = Convert.ToInt32(lblAuctionSaleID.Text.ToString());

            sale.SaleDate = DateTime.Now;

            sale.AuctionID = auctionID = Convert.ToInt16(Request["AuctionID"]);


            GVAuction.EditIndex = -1;
            auctionData = auctionService.GetAuctionData(auctionID);
            GVAuction.DataSource = auctionData.Tables[0].DefaultView;
            DataBind();

            //AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
            //       "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
            //       "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Row updating" +
            //       "</label></div>";
        
        }

        protected void gv_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {


            AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                   "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                   "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Row updated" +
                   "</label></div>";
        }

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVAuction.EditIndex = -1;
            auctionData = auctionService.GetAuctionData(auctionID);
            GVAuction.DataSource = auctionData.Tables[0].DefaultView;
            DataBind();


            //AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
            //       "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
            //       "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Row update cancelled" +
            //       "</label></div>";
        }

        protected void DDLBidderNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DDLSaleStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //protected void DDLPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void BTNTotals_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddPayment_Click(object sender, EventArgs e)
        {
            //Create and add payment here
            Payment payment = new Payment();
            payment.AuctionSaleID = 0;
            String auctionSaleIDString = Session["AuctionSaleID"].ToString();
            if (auctionSaleIDString != null && auctionSaleIDString != "")
            {
                payment.AuctionSaleID = Convert.ToInt32(auctionSaleIDString);
            }
            payment.PaymentAmount = Convert.ToDouble(TXTPayment.Text);
            payment.PaymentDate = DateTime.Now;
            payment.PaymentTypeID = Convert.ToInt32(DDLPaymentTypes.SelectedValue.ToString());
            String surcharge = TXTSurcharge.Text;
            surcharge = surcharge.Replace("$", "");
            surcharge = surcharge.Replace(",", "");
            if (surcharge != null && surcharge != "")
            {
                payment.Surcharges = Convert.ToDouble(surcharge);
            }
            else
            {
                payment.Surcharges = 0.00;
            }

            if (payment.AuctionSaleID == 0)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                       "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                       "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Could not retrieve AuctionSaleID" +
                       "</label></div>";
            }
            else
            {
                createPayment(payment);
            }

            //Recalculate the totals

            //Success message
            AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
            "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
            "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Payment was added! " + TXTSurcharge.Text +
            "</label></div>";
            
            GVAuction.EditIndex = -1;
            auctionData = auctionService.GetAuctionData(auctionID);
            GVAuction.DataSource = auctionData.Tables[0].DefaultView;
            DataBind();
        }

        protected void txtPayment_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPaymentModal();", true);
            
        }

        //AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
        //       "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
        //       "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Test" +
        //       "</label></div>";


        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPaymentModal();", true);
    }
}
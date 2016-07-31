﻿using AMS.App_Code;
using AMS.App_Code.SuppportClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        AuctionMainDAL auctionMainService = new AuctionMainDAL();
        //BuyerDAL buyerService = new BuyerDAL();
        DataAction dataAction = new DataAction();
        int auctionID = 0;
        int counter = 0;
        GST gst = new GST();
        
        Auction auction = new Auction();
        AuctionDAL auctionService = new AuctionDAL();

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

            gst = auctionMainService.GetActiveGST();

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
                    auction = auctionService.getAuction(auctionID);
                    
                    paymentTypes = auctionMainService.GetPaymentTypes();

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

                        auctionData = postProcessAuctionData(auctionMainService.GetAuctionData(auctionID));


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

        protected DataSet postProcessAuctionData(DataSet tempAuctionData)
        {
            DataSet newAuctionData = new DataSet();
            DataTable tempTable = new DataTable();

            foreach (DataRow row in tempAuctionData.Tables[0].Rows)
            {
                row["GST"] = Convert.ToDouble(gst.GSTPercent) / 100 * (Convert.ToDouble(row["SellingPrice"]) + Convert.ToDouble(row["BuyersFee"]));
                row["Total"] = Convert.ToDouble(row["SellingPrice"]) + Convert.ToDouble(row["BuyersFee"]) + Convert.ToDouble(row["GST"]);

                row["NetTotal"] = Convert.ToDouble(row["Total"]) - Convert.ToDouble(row["Deposit"]) - Convert.ToDouble(row["Payments"]);

                //tempTable.Rows.Add(row);
            }
            //newAuctionData.Tables.Add(tempTable);

            return tempAuctionData;
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
                    foreach (ListItem ls in DDLBidderNumbers.Items)
                    {
                    }
                    //DDLBidderNumbers.AutoPostBack = true;

                    //DataRowView dr = e.Row.DataItem as DataRowView;
                    String value1 = (e.Row.FindControl("lblBuyerID") as Label).Text;
                    DDLBidderNumbers.Items.FindByValue(value1).Selected = true;
                    (e.Row.FindControl("lblBidderNumber") as Label).Text = DDLBidderNumbers.SelectedItem.Text;


                    DropDownList DDLSaleStatuses = (DropDownList)e.Row.FindControl("DDLSaleStatuses");

                    DDLSaleStatuses.DataSource = ConditionStatuses.Tables[0];
                    DDLSaleStatuses.DataTextField = "Description";
                    DDLSaleStatuses.DataValueField = "ConditionID";
                    DDLSaleStatuses.DataBind();
                    //DDLSaleStatuses.AutoPostBack = true;

                    //DataRowView dr2 = e.Row.DataItem as DataRowView;
                    String value2 = (e.Row.FindControl("lblConditionID") as Label).Text;
                    DDLSaleStatuses.Items.FindByValue(value2).Selected = true;
                    (e.Row.FindControl("lblSaleStatus") as Label).Text = DDLSaleStatuses.SelectedItem.Text;

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
            auctionMainService.UpdateAuctionSale(auctionSale);
        }

        private void createPayment(Payment payment)
        {
            auctionMainService.CreatePayment(payment);
        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Save auction sale ID to the session
            GVAuction.EditIndex = e.NewEditIndex;
            try
            {
                auctionData = postProcessAuctionData(auctionMainService.GetAuctionData(auctionID));
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
            sale.SellingPrice = Convert.ToDouble(txtSellingPrice.Text.ToString());

            TextBox txtBuyersFee = (TextBox)GVAuction.Rows[e.RowIndex].FindControl("txtBuyersFee");
            sale.BuyersFee = Convert.ToDouble(txtBuyersFee.Text.ToString());

            Label lblVehicleID = (Label)GVAuction.Rows[e.RowIndex].FindControl("lblVehicleID");
            sale.VehicleID = Convert.ToInt32(lblVehicleID.Text.ToString());

            Label lblAuctionSaleID = (Label)GVAuction.Rows[e.RowIndex].FindControl("lblAuctionSaleID");
            sale.AuctionSaleID = Convert.ToInt32(lblAuctionSaleID.Text.ToString());

            sale.SaleDate = DateTime.Now;

            sale.AuctionID = auctionID = Convert.ToInt16(Request["AuctionID"]);

            sale.GstID = gst.GSTID;

            try
            {
                updateAuctionSale(sale);

                GVAuction.EditIndex = -1;
                auctionData = postProcessAuctionData(auctionMainService.GetAuctionData(auctionID));
                GVAuction.DataSource = auctionData.Tables[0].DefaultView;
                DataBind();
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }        
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
            auctionData = postProcessAuctionData(auctionMainService.GetAuctionData(auctionID));
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

        private Buyer GetBuyerByID(int buyerID)
        {
            DataTable buyers = buyerService.GetBuyers().Tables["Buyers"];
            Buyer buyer = new Buyer();
            buyer.BuyerID = buyerID;

            foreach (DataRow r in buyers.Rows)
            {
                if (r["BuyerID"].ToString().Equals(buyerID.ToString()))
                {
                    buyer.BuyerFirstName = r["BuyerFirstName"].ToString();
                    buyer.BuyerLastName = r["BuyerLastName"].ToString();
                    buyer.BuyerAddress = r["BuyerAddress"].ToString();
                    buyer.BuyerCity = r["BuyerCity"].ToString();
                    buyer.BuyerProvince = r["BuyerProvince"].ToString();
                    buyer.BuyerPostalCode = r["BuyerPostalCode"].ToString();
                    buyer.BuyerPhone = r["BuyerPhone"].ToString();
                    buyer.BuyerDriverLicense = r["BuyerLicense"].ToString();
                    buyer.BidderNum = Convert.ToInt32(r["BidderNumber"].ToString());
                    buyer.BuyerIsPermanent = Convert.ToBoolean(r["Permanent"].ToString());
                    buyer.IsBanned = Convert.ToBoolean(r["Banned"].ToString());
                    buyer.Notes = r["Notes"].ToString();

                    return buyer;
                }
            }

            throw new Exception("Error: Could not find select buyer by id: " + buyerID);
        }

        private ConditionStatus GetConditionStatusByID(int ConditionStatusID)
        {
            DataTable statuses = dataAction.GetConditionStatus();
            ConditionStatus status = new ConditionStatus();
            status.ConditionID = ConditionStatusID;
            foreach (DataRow r in statuses.Rows)
            {
                if (r["ConditionId"].ToString().Equals(ConditionStatusID.ToString()))
                {
                    status.ConditionDescription = r["Description"].ToString();

                    return status;
                }
            }

            throw new Exception("Error: Could not find select sale status by id: " + ConditionStatusID);
        }
        
        //This code will calculate auction totals and auction details
        protected void BTNTotals_Click(object sender, EventArgs e)
        {
            //TODO: Generate totals detailed report
            auctionData = postProcessAuctionData(auctionMainService.GetAuctionData(auctionID));
            AuctionDAL auctionService = new AuctionDAL();
            Auction auction = auctionService.getAuction(auctionID);

            auction.TotalSellingPrices = 0;
            auction.TotalFees = 0;
            auction.TotalGST = 0;
            auction.GrossTotal = 0;
            auction.DepositsAndPayments = 0;
            auction.Receivables = 0;

            String report = "<table>" + "<tr><td>" + "LOT#" + "</td><td>" + "STATUS" + "</td><td>" + "BUYER NAME" + "</td><td>" + "BUYER PHONE" + "</td><td>" + "SELLING PRICE    " + "</td><td align=right>" + "GRAND TOTAL" + "</td></tr>"; //Lot, sale status, buyer name, buyer phone, selling price, grand total
            // Totals: Total Selling Prices, Total in Fees, Total in GST, Surcharges, Gross Total (Sum of all previous), Deposits and Payments (Together with Surcharges), Receivables (difference between gross total and deposits and payments)

            if (auctionData.Tables.Count > 0 && auctionData.Tables[0].Rows.Count > 0)
            {
                
                foreach (DataRow row in auctionData.Tables[0].Rows)
                {
                    //Checking if the car was actually sold
                    if (!(row["BuyerID"].ToString().Equals("1")))
                    {
                        if ((row["ConditionID"].ToString().Equals("4")) || (row["ConditionID"].ToString().Equals("5")))
                        {
                            //If the car is sold, adding it to the totals with the buyer
                            //Get buyer info
                            Buyer buyer = GetBuyerByID(Convert.ToInt32(row["BuyerID"].ToString()));
                            ConditionStatus status = GetConditionStatusByID(Convert.ToInt32(row["ConditionID"].ToString()));

                            report += "<tr><td>" + row["LotNumber"].ToString();
                            report += "</td><td>" + status.ConditionDescription;//row["SALE_STATUS"].ToString(); //TODO: Sale status needs to be a hidden column
                            report += "</td><td>" + buyer.BuyerFirstName + " " + buyer.BuyerLastName;//row["BUYER_NAME"].ToString(); //TODO: Buyer name needs to be a hidden column
                            report += "</td><td>" + buyer.BuyerPhone;//row["BUYER_PHONE"].ToString(); //TODO: Buyer phone needs to be a hidden column
                            report += "</td><td align=right>" + Convert.ToDouble(row["SellingPrice"]).ToString("C2");
                            report += "</td><td align=right>" + Convert.ToDouble(row["Total"]).ToString("C2");
                            auction.AuctionTotal += Convert.ToDouble(auctionData.Tables[0].Rows[0]["Total"].ToString());
                            //auction.AuctionTotal += Convert.ToDouble(auctionData.Tables[0].Rows[0]["Payments"].ToString()); //No payments tracking within auction class atm
                            auction.Surcharges += Convert.ToDouble(auctionData.Tables[0].Rows[0]["Surcharges"].ToString());
                            //auction.CashCharges += Convert.ToDouble(auctionData.Tables[0].Rows[0]["CashCharges"].ToString()); //No Cash charges tracking within dataset atm
                            //auction.ChequeCharges += Convert.ToDouble(auctionData.Tables[0].Rows[0]["ChequeCharges"].ToString()); //No Cheque Charges tracking within dataset atm
                            //auction.CreditCardCharges += Convert.ToDouble(auctionData.Tables[0].Rows[0]["CreditCardCharges"].ToString()); //No Credit Card Charges tracking within dataset atm

                            auction.TotalSellingPrices += Convert.ToDouble(row["SellingPrice"].ToString());
                            auction.TotalFees += Convert.ToDouble(row["BuyersFee"].ToString());
                            auction.TotalGST += Convert.ToDouble(row["GST"].ToString());
                            auction.GrossTotal += Convert.ToDouble(row["Total"].ToString());
                            auction.DepositsAndPayments += (Convert.ToDouble(row["Deposit"].ToString()) + Convert.ToDouble(row["Payments"].ToString()));
                            auction.Receivables = auction.GrossTotal - auction.DepositsAndPayments;
                        }
                    }
                }
            }
            else
            {
                //Alert about no cars belonging to an auction
                AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "No cars assigned to the auction at the moment!" +
                "</label></div>";
            }
            report += "</table>";
            Session["AuctionTotals"] = report;
            Session["AuctionDetails"] = auction;
            Response.Redirect("~/Documents/AuctionTotals");
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
            
            //Success message
            AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
            "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
            "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Payment was added! " +
            "</label></div>";
            
            GVAuction.EditIndex = -1;
            auctionData = postProcessAuctionData(auctionMainService.GetAuctionData(auctionID));
            GVAuction.DataSource = auctionData.Tables[0].DefaultView;
            DataBind();
        }

        protected void txtPayment_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPaymentModal();", true);
            
        }


        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Check if there are payments against this sale, and if there aren't any, delete the sale.
            Label lblPayments = (Label)GVAuction.Rows[e.RowIndex].FindControl("lblPayments");
            Double payments = Convert.ToDouble(lblPayments.Text.ToString().Replace("$",""));

            if (payments > 0)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Could not delete sale because payments were already made against it" +
                "</label></div>";
            }
            else
            {
                Label lblAuctionSaleID = (Label)GVAuction.Rows[e.RowIndex].FindControl("lblAuctionSaleID");
                int auctionSaleID = Convert.ToInt32(lblAuctionSaleID.Text.ToString());

                try
                {
                    auctionMainService.DeleteAuctionSale(auctionSaleID);

                    //Success message
                    AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Vehicle Sale record was successfully deleted! " +
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
        }
        
        protected void BTNGenerateAuctionCarList_Click(object sender, EventArgs e)
        {
            try
            {
                auctionData = postProcessAuctionData(auctionMainService.GetAuctionData(auctionID));

                String vehicleList = "<table border=\"1\">" + "<tr><td>" + "LOT#" + "</td><td>" + "YEAR" + "</td><td>" + "MAKE/MODEL" + "</td><td>" + "VIN" + "</td><td>" + "MILEAGE" + "</td><td>" 
                + "OPTIONS           "
                + "</td><td>" + "STATUS"
                + "</td><td>" + "CONS"
                + "</td><td>" + "APPRAISAL"
                + "</td><td>" + "RESERVE"
                + "</td><td>" + "PRICE"
                + "</td><td>" + "BID #"
                + "</td></tr>";
                if (auctionData.Tables.Count > 0 && auctionData.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in auctionData.Tables[0].Rows)
                    {
                        Vehicle car = dataAction.GetVehicleByID(Convert.ToInt32(row["VehicleID"]));
                        vehicleList += "<tr><td>" + car.LotNumber;
                        vehicleList += "</td><td>" + car.Year;
                        vehicleList += "</td><td>" + car.Make + " " + car.Model;
                        vehicleList += "</td><td>" + car.Vin;
                        vehicleList += "</td><td>" + car.Mileage;
                        vehicleList += "</td><td>" + car.Options;
                        vehicleList += "</td><td>" + car.Province;
                        vehicleList += "</td><td>"; // + car.;//Cons
                        vehicleList += "</td><td>"; // + car.;//appraisal
                        vehicleList += "</td><td>"; // + car.;//Reserve
                        vehicleList += "</td><td>"; // + car.;//Price sold at
                        vehicleList += "</td><td>"; // + car.;//Bid #
                        vehicleList += "</td></tr>";
                    }
                }

                //TODO: Generate Auction Car List
                Session["vehicleList"] = vehicleList;
                Session["AuctionDetails"] = auction;
                Response.Redirect("~/Documents/LogSheet");
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

        protected void BTNAddCarsToAuction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory?AuctionID=" + auctionID.ToString() + "&AddingVehicles=true" + "&AuctionDate=" + auction.AuctionDate.ToString());
            
        }

        protected void BTNBidderAcknowledgements_Click(object sender, EventArgs e)
        {

        }

        //AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
        //       "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
        //       "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Test" +
        //       "</label></div>";


        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPaymentModal();", true);
    }
}
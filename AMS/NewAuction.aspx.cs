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
    public partial class NewAuction : System.Web.UI.Page
    {
        DataSet vehiclesForSale = new DataSet();
        AuctionDAL auctionService = new AuctionDAL();
        GST activeGST = new AuctionMainDAL().GetActiveGST();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    vehiclesForSale = auctionService.viewVehiclesForSale();

                    LBAuctionCars.DataTextField = "DisplayInfo";
                    LBAuctionCars.DataValueField = "VehicleID";
                    LBAuctionCars.DataSource = vehiclesForSale;
                    LBAuctionCars.DataBind();
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

            try
            {
                int auctionID = 0;
                int id = 0;

                //Create Auction Object
                Auction auction = new Auction();
                auction.AuctionDate = Convert.ToDateTime(TXTDate.Text.ToString());
                auction.AuctionTotal = 0.00;
                auction.Surcharges = 0.00;
                auction.CashCharges = 0.00;
                auction.ChequeCharges = 0.00;
                auction.CreditCardCharges = 0.00;

                //Create Auction inside DB
                auctionID = auctionService.createAuction(auction);

                if (auctionID > 0)
                {
                    //Success message
                    AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Auction was created with internal ID: " + auctionID.ToString() +
                    "</label></div>";

                    double percentage = 0.00;
                    double totalSelected = 0.00;
                    double current = 0.00;

                    //Get the total number of selected cars
                    foreach (ListItem listItem in LBAuctionCars.Items)
                    {
                        if (listItem.Selected)
                        {
                            totalSelected += 1;
                        }
                    }

                    if (totalSelected > 0.00)
                    {
                        foreach (ListItem listItem in LBAuctionCars.Items)
                        {
                            if (listItem.Selected)
                            {
                                current += 1;
                                percentage = (current / totalSelected) * 100;

                                //Assembling AuctionSale object
                                AuctionSale auctionSale = new AuctionSale();
                                auctionSale.AuctionID = auctionID;
                                auctionSale.SaleDate = Convert.ToDateTime(TXTDate.Text.ToString());

                                //Not Sold Sale Status
                                auctionSale.ConditionID = 1;
                                auctionSale.VehicleID =Convert.ToInt32(listItem.Value);
                                //Assigning an empty Buyer
                                auctionSale.BuyerID = 1;
                                auctionSale.SellingPrice = 0.00;
                                auctionSale.BidderNumber = 0;
                                //default buyer's fee for vehicles
                                auctionSale.BuyersFee = 250.00;
                                auctionSale.Deposit = 0.00;
                                auctionSale.GstID = activeGST.GSTID;
                                auctionSale.Notes = "";
                                
                                //Saving object to the database
                                id = auctionService.createAuctionSale(auctionSale);

                                //Show Progress
                                //ProgressBar.InnerHtml = "<div class=\"progress progress-striped\">" +
                                //"<div class=\"progress-bar progress-bar-success\" style=\"width: " + percentage + "%\">" +
                                //"Creating" +
                                //"</div>" +
                                //"</div>";

                                //System.Threading.Thread.Sleep(5000);
                            }
                        }

                        //Success message
                        AlertDiv.InnerHtml += "<div class=\"alert alert-success fade in\">" +
                        "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                        "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Vehicles were added successfully!" +
                        "</label></div>";
                    }
                }
                else
                {
                    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Could not create auction, please contact your tech support" +
                    "</label></div>";
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
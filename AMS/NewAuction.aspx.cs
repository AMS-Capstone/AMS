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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                vehiclesForSale = auctionService.viewVehiclesForSale();

                LBAuctionCars.DataTextField = "DisplayInfo";
                LBAuctionCars.DataValueField = "VehicleID";
                LBAuctionCars.DataSource = vehiclesForSale;
                LBAuctionCars.DataBind();
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
                auction.AucioneerFirstName  

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

                            //Assemble AuctionSale object


                            //Call DAL
                            //int id = auctionService.createAuctionSale();

                            //Show Progress
                            ProgressBar.InnerHtml = "<div class=\"progress progress-striped\">" +
                            "<div class=\"progress-bar progress-bar-success\" style=\"width: " + percentage + "%\">" +
                            "Creating" +
                            "</div>" +
                            "</div>";
                        }
                    }

                    //Success message
                    AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Auction was created with internal ID: " + id.ToString() +
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